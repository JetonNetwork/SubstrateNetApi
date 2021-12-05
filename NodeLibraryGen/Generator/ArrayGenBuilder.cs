﻿using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NodeLibraryGen
{
    public class ArrayGenBuilder : BaseBuilder
    {
        public static int Counter = 0;
        private ArrayGenBuilder(uint id, NodeTypeArray typeDef, Dictionary<uint, string> typeDict)
        {
            Success = true;

            Id = id;

            TargetUnit = new CodeCompileUnit();
            CodeNamespace importsNamespace = new()
            {
                Imports = {
                    new CodeNamespaceImport("SubstrateNetApi.Model.Custom.Runtime"),
                    new CodeNamespaceImport("SubstrateNetApi.Model.Types.Base"),
                    new CodeNamespaceImport("SubstrateNetApi.Model.Types.Primitive"),
                    new CodeNamespaceImport("SubstrateNetApi.Model.Types.Sequence"),
                    new CodeNamespaceImport("SubstrateNetApi.Model.Types.Composite"),
                    new CodeNamespaceImport("SubstrateNetApi.Model.Types.Enum"),
                    new CodeNamespaceImport("System.Collections.Generic"),
                    new CodeNamespaceImport("System")
                }
            };

            if (!typeDict.TryGetValue(typeDef.TypeId, out string baseType))
            {
                Success = false;
                baseType = "Unknown";
            }

            ClassName = $"Arr{typeDef.Length}{baseType}";

            NameSpace = "SubstrateNetApi.Model." + "Base";

            CodeNamespace typeNamespace = new(NameSpace);
            TargetUnit.Namespaces.Add(importsNamespace);
            TargetUnit.Namespaces.Add(typeNamespace);

            if (baseType.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                Counter++;
                ClassName = $"Arr{typeDef.Length}Special" + Counter++;
            }

            TargetClass = new CodeTypeDeclaration(ClassName)
            {
                IsClass = true,
                TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed
            };
            TargetClass.BaseTypes.Add(new CodeTypeReference("BaseType"));
            TargetClass.Comments.Add(new CodeCommentStatement("<summary>", true));
            TargetClass.Comments.Add(new CodeCommentStatement($">> Array", true));
            if (typeDef.Docs != null)
            {
                foreach (var doc in typeDef.Docs)
                {
                    TargetClass.Comments.Add(new CodeCommentStatement(doc, true));
                }
            }
            TargetClass.Comments.Add(new CodeCommentStatement("</summary>", true));
            typeNamespace.Types.Add(TargetClass);

            // Declaring a name method
            CodeMemberMethod nameMethod = new()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = "TypeName",
                ReturnType = new CodeTypeReference(typeof(System.String))
            };
            var methodRef1 = new CodeMethodReferenceExpression(new CodeObjectCreateExpression(baseType, Array.Empty<CodeExpression>()), "TypeName()");
            var methodRef2 = new CodeMethodReferenceExpression(new CodeThisReferenceExpression(), "TypeSize");

            // Declaring a return statement for method ToString.
            CodeMethodReturnStatement returnStatement =
                new()
                {
                    Expression =
                        new CodeMethodInvokeExpression(
                        new CodeTypeReferenceExpression("System.String"), "Format",
                        new CodePrimitiveExpression("[{0}; {1}]"),
                        methodRef1, methodRef2)
                };
            nameMethod.Statements.Add(returnStatement);
            TargetClass.Members.Add(nameMethod);

            CodeMemberProperty sizeProperty = new()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = "TypeSize",
                Type = new CodeTypeReference(typeof(System.Int32))
            };
            sizeProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression((int)typeDef.Length)));
            TargetClass.Members.Add(sizeProperty);


            CodeMemberMethod encodeMethod = GetEncode();
            TargetClass.Members.Add(encodeMethod);

            CodeMemberMethod decodeMethod = GetDecode(baseType);
            TargetClass.Members.Add(decodeMethod);


            CodeMemberField valueField = new()
            {
                Attributes = MemberAttributes.Private,
                Name = "_value",
                Type = new CodeTypeReference($"{baseType}[]")
            };
            TargetClass.Members.Add(valueField);
            CodeMemberProperty valueProperty = new()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = "Value",
                HasGet = true,
                HasSet = true,
                Type = new CodeTypeReference($"{baseType}[]")
            };
            valueProperty.GetStatements.Add(new CodeMethodReturnStatement(
                new CodeFieldReferenceExpression(
                new CodeThisReferenceExpression(), valueField.Name)));
            valueProperty.SetStatements.Add(new CodeAssignStatement(
                new CodeFieldReferenceExpression(
                    new CodeThisReferenceExpression(), valueField.Name),
                                    new CodePropertySetValueReferenceExpression()));


            CodeMemberMethod createMethod = new()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Name = "Create"
            };
            createMethod.Parameters.Add(new()
            {
                Type = new CodeTypeReference($"{baseType}[]"),
                Name = "array"
            });
            createMethod.Statements.Add(new CodeSnippetExpression("Value = array"));
            createMethod.Statements.Add(new CodeSnippetExpression("Bytes = Encode()"));
            TargetClass.Members.Add(createMethod);

            TargetClass.Members.Add(valueProperty);
        }

        private CodeMemberMethod GetDecode(string baseType)
        {
            var decodeMethod = SimpleMethod("Decode");
            CodeParameterDeclarationExpression param1 = new()
            {
                Type = new CodeTypeReference("System.Byte[]"),
                Name = "byteArray"
            };
            decodeMethod.Parameters.Add(param1);
            CodeParameterDeclarationExpression param2 = new()
            {
                Type = new CodeTypeReference("System.Int32"),
                Name = "p",
                Direction = FieldDirection.Ref
            };
            decodeMethod.Parameters.Add(param2);
            decodeMethod.Statements.Add(new CodeSnippetExpression("var start = p"));
            decodeMethod.Statements.Add(new CodeSnippetExpression($"var array = new {baseType}[TypeSize]"));
            decodeMethod.Statements.Add(new CodeSnippetExpression("for (var i = 0; i < array.Length; i++) " +
                "{" +
                $"var t = new {baseType}();" +
                "t.Decode(byteArray, ref p);" +
                "array[i] = t;" +
                "}"));
            decodeMethod.Statements.Add(new CodeSnippetExpression("var bytesLength = p - start"));
            decodeMethod.Statements.Add(new CodeSnippetExpression("Bytes = new byte[bytesLength]"));
            decodeMethod.Statements.Add(new CodeSnippetExpression("Array.Copy(byteArray, start, Bytes, 0, bytesLength)"));
            decodeMethod.Statements.Add(new CodeSnippetExpression("Value = array"));
            return decodeMethod;
        }

        private CodeMemberMethod GetEncode()
        {
            CodeMemberMethod encodeMethod = new()
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Override,
                Name = "Encode",
                ReturnType = new CodeTypeReference("System.Byte[]")
            };
            encodeMethod.Statements.Add(new CodeSnippetExpression("var result = new List<byte>()"));
            encodeMethod.Statements.Add(new CodeSnippetExpression("foreach (var v in Value)" +
                "{" +
                "result.AddRange(v.Encode());" +
                "}"));
            encodeMethod.Statements.Add(new CodeSnippetExpression("return result.ToArray()"));
            return encodeMethod;
        }

        public static ArrayGenBuilder Create(uint id, NodeTypeArray nodeType, Dictionary<uint, string> typeDict)
        {
            return new ArrayGenBuilder(id, nodeType, typeDict);
        }

        public (string, string) Build(out bool success)
        {
            success = Success;
            if (Success)
            {
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CodeGeneratorOptions options = new()
                {
                    BracingStyle = "C"
                };
                var path = Path.Combine(NameSpace, ClassName + ".cs");
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (StreamWriter sourceWriter = new(path))
                {
                    provider.GenerateCodeFromCompileUnit(
                        TargetUnit, sourceWriter, options);
                }
            }
            return (ClassName, NameSpace);
        }
    }
}
