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
using SubstrateNetApi.Model.PalletBalances;
using SubstrateNetApi.Model.SpCore;
using SubstrateNetApi.Model.SpRuntime;
using SubstrateNetApi.Model.Types;
using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace SubstrateNetApi.Model.PalletBalances
{
    
    
    public sealed class BalancesStorage
    {
        
        // Substrate client for the storage calls.
        private SubstrateNetApi.SubstrateClient _client;
        
        public BalancesStorage(SubstrateNetApi.SubstrateClient client)
        {
            this._client = client;
        }
        
        public static string TotalIssuanceParams()
        {
            var parameters = RequestGenerator.GetStorage("Balances", "TotalIssuance", Storage.Type.Plain);
            return parameters;
        }
        
        /// <summary>
        /// >> TotalIssuance
        /// </summary>
        public async Task<SubstrateNetApi.Model.Types.Primitive.U128> TotalIssuance(CancellationToken token)
        {
            string parameters = BalancesStorage.TotalIssuanceParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.Types.Primitive.U128>(parameters, token);
        }
        
        public static string AccountParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Account", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> Account
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBalances.AccountData> Account(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = BalancesStorage.AccountParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBalances.AccountData>(parameters, token);
        }
        
        public static string LocksParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Locks", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> Locks
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec> Locks(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = BalancesStorage.LocksParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.WeakBoundedVec>(parameters, token);
        }
        
        public static string ReservesParams(SubstrateNetApi.Model.SpCore.AccountId32 key)
        {
            var keyParams = new IType[] { key };
            var parameters = RequestGenerator.GetStorage("Balances", "Reserves", Storage.Type.Map, new[] {Storage.Hasher.BlakeTwo128Concat}, keyParams);
            return parameters;
        }
        
        /// <summary>
        /// >> Reserves
        /// </summary>
        public async Task<SubstrateNetApi.Model.FrameSupport.BoundedVec> Reserves(SubstrateNetApi.Model.SpCore.AccountId32 key, CancellationToken token)
        {
            string parameters = BalancesStorage.ReservesParams(key);
            return await _client.GetStorageAsync<SubstrateNetApi.Model.FrameSupport.BoundedVec>(parameters, token);
        }
        
        public static string StorageVersionParams()
        {
            var parameters = RequestGenerator.GetStorage("Balances", "StorageVersion", Storage.Type.Plain);
            return parameters;
        }
        
        /// <summary>
        /// >> StorageVersion
        /// </summary>
        public async Task<SubstrateNetApi.Model.PalletBalances.EnumReleases> StorageVersion(CancellationToken token)
        {
            string parameters = BalancesStorage.StorageVersionParams();
            return await _client.GetStorageAsync<SubstrateNetApi.Model.PalletBalances.EnumReleases>(parameters, token);
        }
    }
    
    public sealed class BalancesCalls
    {
        
        /// <summary>
        /// >> transfer
        /// </summary>
        public static Method Transfer(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress dest, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(6, "Balances", 0, "transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> set_balance
        /// </summary>
        public static Method SetBalance(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress who, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> new_free, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> new_reserved)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(new_free.Encode());
            byteArray.AddRange(new_reserved.Encode());
            return new Method(6, "Balances", 1, "set_balance", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_transfer
        /// </summary>
        public static Method ForceTransfer(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress source, SubstrateNetApi.Model.SpRuntime.EnumMultiAddress dest, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(source.Encode());
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(6, "Balances", 2, "force_transfer", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_keep_alive
        /// </summary>
        public static Method TransferKeepAlive(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress dest, BaseCom<SubstrateNetApi.Model.Types.Primitive.U128> value)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(value.Encode());
            return new Method(6, "Balances", 3, "transfer_keep_alive", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> transfer_all
        /// </summary>
        public static Method TransferAll(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress dest, SubstrateNetApi.Model.Types.Primitive.Bool keep_alive)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(dest.Encode());
            byteArray.AddRange(keep_alive.Encode());
            return new Method(6, "Balances", 4, "transfer_all", byteArray.ToArray());
        }
        
        /// <summary>
        /// >> force_unreserve
        /// </summary>
        public static Method ForceUnreserve(SubstrateNetApi.Model.SpRuntime.EnumMultiAddress who, SubstrateNetApi.Model.Types.Primitive.U128 amount)
        {
            System.Collections.Generic.List<byte> byteArray = new List<byte>();
            byteArray.AddRange(who.Encode());
            byteArray.AddRange(amount.Encode());
            return new Method(6, "Balances", 5, "force_unreserve", byteArray.ToArray());
        }
    }
    
    /// <summary>
    /// >> Endowed
    /// </summary>
    public sealed class EventEndowed : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> DustLost
    /// </summary>
    public sealed class EventDustLost : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> Transfer
    /// </summary>
    public sealed class EventTransfer : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> BalanceSet
    /// </summary>
    public sealed class EventBalanceSet : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> Deposit
    /// </summary>
    public sealed class EventDeposit : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> Reserved
    /// </summary>
    public sealed class EventReserved : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> Unreserved
    /// </summary>
    public sealed class EventUnreserved : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128>
    {
    }
    
    /// <summary>
    /// >> ReserveRepatriated
    /// </summary>
    public sealed class EventReserveRepatriated : BaseTuple<SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.SpCore.AccountId32, SubstrateNetApi.Model.Types.Primitive.U128, SubstrateNetApi.Model.FrameSupport.EnumBalanceStatus>
    {
    }
    
    public enum BalancesErrors
    {
        
        /// <summary>
        /// >> VestingBalance
        /// </summary>
        VestingBalance,
        
        /// <summary>
        /// >> LiquidityRestrictions
        /// </summary>
        LiquidityRestrictions,
        
        /// <summary>
        /// >> InsufficientBalance
        /// </summary>
        InsufficientBalance,
        
        /// <summary>
        /// >> ExistentialDeposit
        /// </summary>
        ExistentialDeposit,
        
        /// <summary>
        /// >> KeepAlive
        /// </summary>
        KeepAlive,
        
        /// <summary>
        /// >> ExistingVestingSchedule
        /// </summary>
        ExistingVestingSchedule,
        
        /// <summary>
        /// >> DeadAccount
        /// </summary>
        DeadAccount,
        
        /// <summary>
        /// >> TooManyReserves
        /// </summary>
        TooManyReserves,
    }
}
