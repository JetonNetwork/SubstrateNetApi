//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Extrinsics;
using SubstrateNetApi.Model.FrameSupport;
using SubstrateNetApi.Model.Meta;
using SubstrateNetApi.Model.PalletIdentity;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.SpRuntime;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletIdentity
{
    
    
    public sealed class IdentityStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public IdentityStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        /// <summary>
        /// >> IdentityOfParams
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string IdentityOfParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "IdentityOf", SubstrateNetApi.Model.Meta.Storage.Type.Map, new SubstrateNetApi.Model.Meta.Storage.Hasher[] {
                        SubstrateNetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new SubstrateNetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> IdentityOf
        ///  Information that is pertinent to identify the entity behind an account.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletIdentity.Registration> IdentityOf(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.IdentityOfParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletIdentity.Registration>(parameters, token);
        }
        
        /// <summary>
        /// >> SuperOfParams
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public static string SuperOfParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SuperOf", SubstrateNetApi.Model.Meta.Storage.Type.Map, new SubstrateNetApi.Model.Meta.Storage.Hasher[] {
                        SubstrateNetApi.Model.Meta.Storage.Hasher.BlakeTwo128Concat}, new SubstrateNetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SuperOf
        ///  The super-identity of an alternative "sub" identity together with its name, within that
        ///  context. If the account is not some other account's sub-identity, then just `None`.
        /// </summary>
        public async Task<BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32,SubstrateNetApi.Model.PalletIdentity.EnumData>> SuperOf(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SuperOfParams(key);
            return await _client.GetStorageAsync<BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32,SubstrateNetApi.Model.PalletIdentity.EnumData>>(parameters, token);
        }
        
        /// <summary>
        /// >> SubsOfParams
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public static string SubsOfParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            return RequestGenerator.GetStorage("Identity", "SubsOf", SubstrateNetApi.Model.Meta.Storage.Type.Map, new SubstrateNetApi.Model.Meta.Storage.Hasher[] {
                        SubstrateNetApi.Model.Meta.Storage.Hasher.Twox64Concat}, new SubstrateNetApi.Model.Types.IType[] {
                        key});
        }
        
        /// <summary>
        /// >> SubsOf
        ///  Alternative "sub" identities of this account.
        /// 
        ///  The first item is the deposit, the second is a vector of the accounts.
        /// 
        ///  TWOX-NOTE: OK ��� `AccountId` is a secure hash.
        /// </summary>
        public async Task<BaseTuple<SubstrateNetApi.Model.Types.Primitive.U128,SubstrateNetApi.Model.FrameSupport.BoundedVec>> SubsOf(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = IdentityStorage.SubsOfParams(key);
            return await _client.GetStorageAsync<BaseTuple<SubstrateNetApi.Model.Types.Primitive.U128,SubstrateNetApi.Model.FrameSupport.BoundedVec>>(parameters, token);
        }
        
        /// <summary>
        /// >> RegistrarsParams
        ///  The set of registrars. Not expected to get very big as can only be added through a
        ///  special origin (likely a council motion).
        /// 
        ///  The index into this can be cast to `RegistrarIndex` to get a valid value.
        /// </summary>
        public static string RegistrarsParams()
        {
            return RequestGenerator.GetStorage("Identity", "Registrars", SubstrateNetApi.Model.Meta.Storage.Type.Plain);
        }
        
        /// <summary>
        /// >> Registrars
        ///  The set of registrars. Not expected to get very big as can only be added through a
        ///  special origin (likely a council motion).
        /// 
        ///  The index into this can be cast to `RegistrarIndex` to get a valid value.
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.BoundedVec> Registrars(CancellationToken token)
        {
            string parameters = IdentityStorage.RegistrarsParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.BoundedVec>(parameters, token);
        }
    }
    
    public sealed class IdentityCalls
    {
        
        /// <summary>
        /// >> add_registrar
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddRegistrar(SubstrateNetApi.Model.SpCore.AccountId32 account)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(account.Encode());
            return new Method(25, "Identity", 0, "add_registrar", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetIdentity(SubstrateNetApi.Model.PalletIdentity.IdentityInfo info)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(info.Encode());
            return new Method(25, "Identity", 1, "set_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_subs
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetSubs(BaseVec<BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32,SubstrateNetApi.Model.PalletIdentity.EnumData>> subs)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(subs.Encode());
            return new Method(25, "Identity", 2, "set_subs", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> clear_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method ClearIdentity()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(25, "Identity", 3, "clear_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> request_judgement
        /// Identity pallet declaration.
        /// </summary>
        public static Method RequestJudgement(BaseCom<SubstrateNetApi.Model.Types.Primitive.U32> reg_index, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> max_fee)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            byteArray.AddRange(max_fee.Encode());
            return new Method(25, "Identity", 4, "request_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> cancel_request
        /// Identity pallet declaration.
        /// </summary>
        public static Method CancelRequest(SubstrateNetApi.Model.Types.Primitive.U32 reg_index)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            return new Method(25, "Identity", 5, "cancel_request", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_fee
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetFee(BaseCom<SubstrateNetApi.Model.Types.Primitive.U32> index, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> fee)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(fee.Encode());
            return new Method(25, "Identity", 6, "set_fee", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_account_id
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetAccountId(BaseCom<SubstrateNetApi.Model.Types.Primitive.U32> index, SubstrateNetApi.Model.SpCore.AccountId32 @new)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(@new.Encode());
            return new Method(25, "Identity", 7, "set_account_id", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_fields
        /// Identity pallet declaration.
        /// </summary>
        public static Method SetFields(BaseCom<SubstrateNetApi.Model.Types.Primitive.U32> index, SubstrateNetApi.Model.PalletIdentity.BitFlags fields)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(index.Encode());
            byteArray.AddRange(fields.Encode());
            return new Method(25, "Identity", 8, "set_fields", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> provide_judgement
        /// Identity pallet declaration.
        /// </summary>
        public static Method ProvideJudgement(BaseCom<SubstrateNetApi.Model.Types.Primitive.U32> reg_index, SubstrateNetApi.Model.SpRuntime.EnumMultiAddress target, SubstrateNetApi.Model.PalletIdentity.EnumJudgement judgement)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(reg_index.Encode());
            byteArray.AddRange(target.Encode());
            byteArray.AddRange(judgement.Encode());
            return new Method(25, "Identity", 9, "provide_judgement", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> kill_identity
        /// Identity pallet declaration.
        /// </summary>
        public static Method KillIdentity(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress target)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(target.Encode());
            return new Method(25, "Identity", 10, "kill_identity", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> add_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method AddSub(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress sub, SubstrateNetApi.Model.PalletIdentity.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(25, "Identity", 11, "add_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> rename_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RenameSub(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress sub, SubstrateNetApi.Model.PalletIdentity.EnumData data)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            byteArray.AddRange(data.Encode());
            return new Method(25, "Identity", 12, "rename_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> remove_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method RemoveSub(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress sub)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(sub.Encode());
            return new Method(25, "Identity", 13, "remove_sub", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> quit_sub
        /// Identity pallet declaration.
        /// </summary>
        public static Method QuitSub()
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            return new Method(25, "Identity", 14, "quit_sub", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> IdentitySet
    /// A name was set or reset (which will remove all judgements). \[who\]
    /// </summary>
    public sealed class EventIdentitySet : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32>
    {
    }
    
    /// <summary>
    /// >> IdentityCleared
    /// A name was cleared, and the given balance returned. \[who, deposit\]
    /// </summary>
    public sealed class EventIdentityCleared : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> IdentityKilled
    /// A name was removed and the given balance slashed. \[who, deposit\]
    /// </summary>
    public sealed class EventIdentityKilled : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> JudgementRequested
    /// A judgement was asked from a registrar. \[who, registrar_index\]
    /// </summary>
    public sealed class EventJudgementRequested : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
    {
    }
    
    /// <summary>
    /// >> JudgementUnrequested
    /// A judgement request was retracted. \[who, registrar_index\]
    /// </summary>
    public sealed class EventJudgementUnrequested : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
    {
    }
    
    /// <summary>
    /// >> JudgementGiven
    /// A judgement was given by a registrar. \[target, registrar_index\]
    /// </summary>
    public sealed class EventJudgementGiven : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U32>
    {
    }
    
    /// <summary>
    /// >> RegistrarAdded
    /// A registrar was added. \[registrar_index\]
    /// </summary>
    public sealed class EventRegistrarAdded : BaseTuple<SubstrateNetApi.Model.Types.Primitive.U32>
    {
    }
    
    /// <summary>
    /// >> SubIdentityAdded
    /// A sub-identity was added to an identity and the deposit paid. \[sub, main, deposit\]
    /// </summary>
    public sealed class EventSubIdentityAdded : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> SubIdentityRemoved
    /// A sub-identity was removed from an identity and the deposit freed.
    /// \[sub, main, deposit\]
    /// </summary>
    public sealed class EventSubIdentityRemoved : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> SubIdentityRevoked
    /// A sub-identity was cleared, and the given deposit repatriated from the
    /// main identity account to the sub-identity account. \[sub, main, deposit\]
    /// </summary>
    public sealed class EventSubIdentityRevoked : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    public enum IdentityErrors
    {
        
        /// <summary>
        /// >> TooManySubAccounts
        /// Too many subs-accounts.
        /// </summary>
        TooManySubAccounts,
        
        /// <summary>
        /// >> NotFound
        /// Account isn't found.
        /// </summary>
        NotFound,
        
        /// <summary>
        /// >> NotNamed
        /// Account isn't named.
        /// </summary>
        NotNamed,
        
        /// <summary>
        /// >> EmptyIndex
        /// Empty index.
        /// </summary>
        EmptyIndex,
        
        /// <summary>
        /// >> FeeChanged
        /// Fee is changed.
        /// </summary>
        FeeChanged,
        
        /// <summary>
        /// >> NoIdentity
        /// No identity found.
        /// </summary>
        NoIdentity,
        
        /// <summary>
        /// >> StickyJudgement
        /// Sticky judgement.
        /// </summary>
        StickyJudgement,
        
        /// <summary>
        /// >> JudgementGiven
        /// Judgement given.
        /// </summary>
        JudgementGiven,
        
        /// <summary>
        /// >> InvalidJudgement
        /// Invalid judgement.
        /// </summary>
        InvalidJudgement,
        
        /// <summary>
        /// >> InvalidIndex
        /// The index is invalid.
        /// </summary>
        InvalidIndex,
        
        /// <summary>
        /// >> InvalidTarget
        /// The target is invalid.
        /// </summary>
        InvalidTarget,
        
        /// <summary>
        /// >> TooManyFields
        /// Too many additional fields.
        /// </summary>
        TooManyFields,
        
        /// <summary>
        /// >> TooManyRegistrars
        /// Maximum amount of registrars reached. Cannot add any more.
        /// </summary>
        TooManyRegistrars,
        
        /// <summary>
        /// >> AlreadyClaimed
        /// Account ID is already named.
        /// </summary>
        AlreadyClaimed,
        
        /// <summary>
        /// >> NotSub
        /// Sender is not a sub-account.
        /// </summary>
        NotSub,
        
        /// <summary>
        /// >> NotOwned
        /// Sub-account isn't owned by sender.
        /// </summary>
        NotOwned,
    }
}
