//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Calls;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Composite;
using SubstrateNetApi.Model.Types.Enum;
using SubstrateNetApi.Model.Types.Primitive;
using SubstrateNetApi.Model.Types.Sequence;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.Custom.Calls
{
    
    
    /// <summary>
    /// >> Path: frame_system.pallet.Call
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    /// </summary>
    public sealed class FrameSystem
    {
        
        /// <summary>
        /// >> Extrinsic: fill_block
        /// A dispatch that will fill the block weight up to the given ratio.
        /// </summary>
        public GenericExtrinsicCall FillBlock(Perbill ratio)
        {
            return new GenericExtrinsicCall("System", "fill_block", ratio);
        }
        
        /// <summary>
        /// >> Extrinsic: remark
        /// Make some on-chain remark.
        /// 
        /// # <weight>
        /// - `O(1)`
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall Remark(BaseVec<U8> remark)
        {
            return new GenericExtrinsicCall("System", "remark", remark);
        }
        
        /// <summary>
        /// >> Extrinsic: set_heap_pages
        /// Set the number of pages in the WebAssembly environment's heap.
        /// 
        /// # <weight>
        /// - `O(1)`
        /// - 1 storage write.
        /// - Base Weight: 1.405 ��s
        /// - 1 write to HEAP_PAGES
        /// - 1 digest item
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall SetHeapPages(U64 pages)
        {
            return new GenericExtrinsicCall("System", "set_heap_pages", pages);
        }
        
        /// <summary>
        /// >> Extrinsic: set_code
        /// Set the new runtime code.
        /// 
        /// # <weight>
        /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`
        /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is
        ///   expensive).
        /// - 1 storage write (codec `O(C)`).
        /// - 1 digest item.
        /// - 1 event.
        /// The weight of this function is dependent on the runtime, but generally this is very
        /// expensive. We will treat this as a full block.
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall SetCode(BaseVec<U8> code)
        {
            return new GenericExtrinsicCall("System", "set_code", code);
        }
        
        /// <summary>
        /// >> Extrinsic: set_code_without_checks
        /// Set the new runtime code without doing any checks of the given `code`.
        /// 
        /// # <weight>
        /// - `O(C)` where `C` length of `code`
        /// - 1 storage write (codec `O(C)`).
        /// - 1 digest item.
        /// - 1 event.
        /// The weight of this function is dependent on the runtime. We will treat this as a full
        /// block. # </weight>
        /// </summary>
        public GenericExtrinsicCall SetCodeWithoutChecks(BaseVec<U8> code)
        {
            return new GenericExtrinsicCall("System", "set_code_without_checks", code);
        }
        
        /// <summary>
        /// >> Extrinsic: set_changes_trie_config
        /// Set the new changes trie configuration.
        /// 
        /// # <weight>
        /// - `O(1)`
        /// - 1 storage write or delete (codec `O(1)`).
        /// - 1 call to `deposit_log`: Uses `append` API, so O(1)
        /// - Base Weight: 7.218 ��s
        /// - DB Weight:
        ///     - Writes: Changes Trie, System Digest
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall SetChangesTrieConfig(BaseOpt<ChangesTrieConfiguration> changes_trie_config)
        {
            return new GenericExtrinsicCall("System", "set_changes_trie_config", changes_trie_config);
        }
        
        /// <summary>
        /// >> Extrinsic: set_storage
        /// Set some items of storage.
        /// 
        /// # <weight>
        /// - `O(I)` where `I` length of `items`
        /// - `I` storage writes (`O(1)`).
        /// - Base Weight: 0.568 * i ��s
        /// - Writes: Number of items
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall SetStorage(BaseVec<BaseTuple<BaseVec<U8>,BaseVec<U8>>> items)
        {
            return new GenericExtrinsicCall("System", "set_storage", items);
        }
        
        /// <summary>
        /// >> Extrinsic: kill_storage
        /// Kill some items from storage.
        /// 
        /// # <weight>
        /// - `O(IK)` where `I` length of `keys` and `K` length of one key
        /// - `I` storage deletions.
        /// - Base Weight: .378 * i ��s
        /// - Writes: Number of items
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall KillStorage(BaseVec<BaseVec<U8>> keys)
        {
            return new GenericExtrinsicCall("System", "kill_storage", keys);
        }
        
        /// <summary>
        /// >> Extrinsic: kill_prefix
        /// Kill all storage items with a key that starts with the given prefix.
        /// 
        /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under
        /// the prefix we are removing to accurately calculate the weight of this function.
        /// 
        /// # <weight>
        /// - `O(P)` where `P` amount of keys with prefix `prefix`
        /// - `P` storage deletions.
        /// - Base Weight: 0.834 * P ��s
        /// - Writes: Number of subkeys + 1
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall KillPrefix(BaseVec<U8> prefix, U32 subkeys)
        {
            return new GenericExtrinsicCall("System", "kill_prefix", prefix, subkeys);
        }
        
        /// <summary>
        /// >> Extrinsic: remark_with_event
        /// Make some on-chain remark and emit event.
        /// 
        /// # <weight>
        /// - `O(b)` where b is the length of the remark.
        /// - 1 event.
        /// # </weight>
        /// </summary>
        public GenericExtrinsicCall RemarkWithEvent(BaseVec<U8> remark)
        {
            return new GenericExtrinsicCall("System", "remark_with_event", remark);
        }
    }
}