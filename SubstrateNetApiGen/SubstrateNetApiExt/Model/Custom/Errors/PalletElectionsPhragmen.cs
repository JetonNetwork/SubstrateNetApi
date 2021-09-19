//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SubstrateNetApi.Model.Types.Base;
using SubstrateNetApi.Model.Types.Composite;
using SubstrateNetApi.Model.Types.Enum;
using SubstrateNetApi.Model.Types.Primitive;
using SubstrateNetApi.Model.Types.Sequence;
using System;
using System.Collections.Generic;


namespace SubstrateNetApi.Model.Custom.Errors
{
    
    
    /// <summary>
    /// >> Path: pallet_elections_phragmen.pallet.Error
    /// 
    ///			Custom [dispatch errors](https://substrate.dev/docs/en/knowledgebase/runtime/errors)
    ///			of this pallet.
    ///			
    /// </summary>
    public enum PalletElectionsPhragmen
    {
        
        /// <summary>
        /// >> Event: UnableToVote
        /// Cannot vote when no candidates or members exist.
        /// </summary>
        UnableToVote,
        
        /// <summary>
        /// >> Event: NoVotes
        /// Must vote for at least one candidate.
        /// </summary>
        NoVotes,
        
        /// <summary>
        /// >> Event: TooManyVotes
        /// Cannot vote more than candidates.
        /// </summary>
        TooManyVotes,
        
        /// <summary>
        /// >> Event: MaximumVotesExceeded
        /// Cannot vote more than maximum allowed.
        /// </summary>
        MaximumVotesExceeded,
        
        /// <summary>
        /// >> Event: LowBalance
        /// Cannot vote with stake less than minimum balance.
        /// </summary>
        LowBalance,
        
        /// <summary>
        /// >> Event: UnableToPayBond
        /// Voter can not pay voting bond.
        /// </summary>
        UnableToPayBond,
        
        /// <summary>
        /// >> Event: MustBeVoter
        /// Must be a voter.
        /// </summary>
        MustBeVoter,
        
        /// <summary>
        /// >> Event: ReportSelf
        /// Cannot report self.
        /// </summary>
        ReportSelf,
        
        /// <summary>
        /// >> Event: DuplicatedCandidate
        /// Duplicated candidate submission.
        /// </summary>
        DuplicatedCandidate,
        
        /// <summary>
        /// >> Event: MemberSubmit
        /// Member cannot re-submit candidacy.
        /// </summary>
        MemberSubmit,
        
        /// <summary>
        /// >> Event: RunnerUpSubmit
        /// Runner cannot re-submit candidacy.
        /// </summary>
        RunnerUpSubmit,
        
        /// <summary>
        /// >> Event: InsufficientCandidateFunds
        /// Candidate does not have enough funds.
        /// </summary>
        InsufficientCandidateFunds,
        
        /// <summary>
        /// >> Event: NotMember
        /// Not a member.
        /// </summary>
        NotMember,
        
        /// <summary>
        /// >> Event: InvalidWitnessData
        /// The provided count of number of candidates is incorrect.
        /// </summary>
        InvalidWitnessData,
        
        /// <summary>
        /// >> Event: InvalidVoteCount
        /// The provided count of number of votes is incorrect.
        /// </summary>
        InvalidVoteCount,
        
        /// <summary>
        /// >> Event: InvalidRenouncing
        /// The renouncing origin presented a wrong `Renouncing` parameter.
        /// </summary>
        InvalidRenouncing,
        
        /// <summary>
        /// >> Event: InvalidReplacement
        /// Prediction regarding replacement after member removal is wrong.
        /// </summary>
        InvalidReplacement,
    }
}