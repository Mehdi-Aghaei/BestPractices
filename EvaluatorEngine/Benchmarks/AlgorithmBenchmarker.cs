using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace EvaluatorEngine.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AlgorithmBenchmarker
{
	public const string Input = """
        PcPlnShmrLmBnmcwBhrmcmbHNGFGpwdFFwGNjNbGqNHH
        tzQfRJfWZZztWzVtCTfRzFZjpFjNZjGLHbdHLDdjpb
        CCQTzRLzvQVVfRzJfMPsnBlglgPmBgPmvSrl
        RMfvbbszHTsssFPzDQPggpQJPQ
        NSNcqVtLVGgDlpQBClVB
        hmStGNNLhjNrpWLGSjWrZssbZTMMvTfMnThbRRTs
        fTrTPGTbfftWBBmLjrJL
        DqHwVMqVplDslmlZmpHVwNnShWZFdBBdjWBtWtdtWJSSLS
        MNslpDvVHlwsmpQRgQgCfTTcvcRQ
        pBBhRgDsMsswprBhvgRglZtFGFFRqZtZmRtNqtZPPN
        TdmmzzmdZdqdGFtF
        nmSccCVmSCpDCswMwl
        NptqDsQtDTQzCvlzCpRlRp
        jmZcndmjbZcjrmDvFMFFlwCvzFnF
        jjgLVLrGcdDBNhWQTgHg
        mLVhhfSMSTmMwClHGdpjDHjGdV
        zPrZgJCgbsnrPtZzsCsbpRDjBRHnjGDRldRHppcG
        JJrbsFrZqrgWbbqbrgWzJPNTwhTNCmmvfWCShhhmwwfm
        ftgfljvgfgBTNvtggFDDGLGRDnMDzcQzncGt
        VdbpbVdZwdwrsVVLRrMrDLDBGnBGcM
        wmpWwWsHWBCCCPPvjvmSqlfTTmSNgN
        jSqmzmmSSDRjLMLDwqjNcMMLTTflffWCCsRsTHnHVrfHWTsr
        tdbgZpgBPdgGZGGFTHVpCsCVfVsJpnWl
        FnPQFvbvhFFFbvBwScjhzcqSLLSzSN
        bWdgrWwwFWbgzFWzrmNbdPqttChMSRnmqSPSnqtMRM
        lcPJLDDPPfpMBCRJBtQtMh
        lGDGjTGLLDHPPGjlPTsswsbHNFsNrFNFsrzr
        VmtHfVhBLHVtlhphjZMdnQQZZqZmQDdzQQ
        CPFwPWrvWgrfNgFPCMqZzMDDbznFTqqzDQ
        NNPsfffPCsBLjpVltV
        ssdBBJqJhlTJLsjTJqFFmnmmnnrcmpprmmmPcRlf
        gqtqzSgWQWqmnRPPcNmmQM
        GqbSVtGzvgvgWbZjjBhTdhBsTZBJBZ
        jhNBsPDzLjsVhLSNzgvcvbcwbBWFcgtWCc
        ZQQTTHHnGpMtnpdHpQJfMgrvWWFqbcWWGgrgwCCwwF
        nHpmMnQQMmHpRnHRmMJnnTShPzljzjSNmSDhLsNSPtSh
        GdqnBGFdlqzFnwdSCQZjZLLDZjZRvZLDVvgQ
        PsptsTcftMfcTfhTghVDvvjnRNjVZnvV
        WtPfJTfftJcMTrMnpccFwlCSCGFGCbCwJSbqBl
        GjFLGhjRwFjNSjSdJCBBdQJddbBc
        MVvMMHRzVtHlvlcQBQJHqdpQqCBC
        vDgVztvvmrgrVRrMmsrsmZzZnWhGnNhGWTLfnLwTLhLTjngL
        VljjQJSsrjjrCglsCjsgjVVfDLdZGMdvvGdQMzmvzcDQMc
        HqPBtcpRWwtHbbFwBHZfmfpDfvffDfMfmGvM
        PwHNbcwtqFqnwtNNqPNPPWBTThjhhVTCSJTThssVnSlJJV
        GCccNCrrnCrpnzrnCDPcDDrvHHTBqTPhswqhPTBTTwBhTj
        VfNmRtZgWWHdBdswdjZv
        SmtQfgNmVFgVLVLVmrnMpcDLGCGLGDMpCp
        CrdZdZmPPjrQdRPRDqDLBqBLBSWgWgLDzF
        sQhTNphsVbhhhMJfhNVGqltVSzSllBzStlzFFFWB
        hsMpwQhNMZmPmrwHRj
        cNVpSVRpLHRLsVWWfnfsCshW
        jvqjTgqZPlJZmbPPfbpswsPb
        vlqdTZdtJvqdZjgqZrtRpQFtLFRQczHGzt
        JJQndVQnQgTfNvGf
        ljpbWbmNbDlGTvggGvZf
        mpmRbMmmNDFDmScpzCsdzrnJrsCzrrnM
        tNFtNFFzzjjzjBtVNZVbjZGlpSvTllpWwvnBlWGGBGCC
        fPdcrrgPHrHMMMWlppGJSPwGSnGv
        fmrqrhhfhdRddHrhQqQrfnLZjLtNttZjjRtzjFtRNj
        sphRcpQRhfmnmfpptg
        WVPlGLlSjCjSlGSHJJWZdmbmfvPmmnftbbgDdt
        LJjjqVNjlnCTRcRhhsNcFF
        vwwqttFjwgClRNCCvGNmZZMmJsPJjJpTdMpsZd
        fBLVHHHrFnhHhnrVSTmfdPdPccTTPsMfsJ
        QzVWzznzFbWNGNlt
        vjMddVVmnWpdMndjvhhWfNLpfBsfLLZLBBSqqTZq
        RFlrzQJPSRGzzzzgBZNsgBZTBflfgf
        cQFDRHFDDGCJShCnvwVnnhCn
        hgjlpRRLlPJJhTLJMDnwBndSPBNvMqnN
        FGWVfZsmCbmVzrvtwCSMtMdnDMCw
        VsVmVZfVQDmVFrrmzmGrHHTJgJjhHJcllglLQJRL
        rrTVcTBgsjTffmfWHZTv
        JLdnDlpGlGSLlpwJpHZfFvRZnWzWrHWqFH
        wQDpDrdSlSCblCdwdSLlwQGBthPMsghNsVNVtCNNhNPjhs
        CtCMvNhDMHfDDdffqtDtCflpJlBpvmWWJWwlpwFFvjwB
        rGSbVGZrSsFJjlmBFZWp
        rbbQgzVGrFVSPPGqfhftfqztNtqHtt
        lMGZCGphllZDNshNNmHHND
        PLwjVwJVsHmRrZZw
        ffSdzjfZSjtjSjLtLLFFFGqFzznCpCnCBblQ
        CqRnlzHCRWTlHPTZVQrcQtFsQFTcrQ
        DfJcdBDBcftQjsrsBtjZ
        JDfdGhSvNGhNfffGSfRznPvcRWcqCqmlvlcn
        JPhBBBQCnCJCMhnhMZRrRZgbDgrWrNbglDgR
        jLtSTwtsShwRNpRWrh
        FLLSHsjGLGczvfPfJdfhddnHPC
        BjHBNrWmTjFgJngbJhWd
        vsGttMDtwCMQCJnqqqFJsggqdg
        GFtDSwwMpTrzSSfcfm
        rnWDQvpwWpDDcPjFPPHZjVDZ
        CTJCRmCJcZZZHCCQ
        LdlmdQJNpnLWbrfL
        VdTdcVTZwCRGVGGMVmttlF
        gnrsbngfgQSpBfpMBBBpSgMNNJbmGmlqGDqDNlFFJlGNFz
        gprgQhgpMMMPsrRTCdPZwCwZZCRH
        cHlCVGbbWHWqRNThhcNcmh
        MwQDzpwdJwpBpPDQvrhShfLTTRLfLdjfNRqS
        JwMBBrPsPDwQMDPPBPQJwMrvWHFbHHlgbsGnnWHnFnRGlblF
        PQPjPDjRRQSFLSlgSmLlfh
        zpLdBddbNCdqGbWJGWpJWWlsFsmmFpwfflFgfHwFhgmh
        nJLdLVnzqqbjRctcPDQVTP
        JdztScztPdSWLJLtgMbCjhvlbPRbjbMvCh
        VZrqfQcFQwGVVFqfrTFTNqhljRHDMvMMGhRDRRHGbDhG
        NZQNVQQpQmrZFQQFwQQVVZgBszJJgznstnmtcztdBSgs
        nFHLNJzFbLJGGLMlTTRZbZRhWRTr
        wVmgBBmtmwlqlWTwTM
        sdvmgcPsCPPQQSMz
        SccCqmQmgBmppLQmpSMjjlJzzsNPMDRbPNPlJM
        VHZvwtZwhZHtdTwrVbNsljlRDlJPDhzsbN
        dZwftVRftmcgpBCmBf
        NTTlVlgNSflqbphFFhNbFp
        wmmLmjwzwbWGLjRmtZZdhZLFtQQLQBFh
        RvjbMjjvMzMWbDWwvzPjvmWSfVfsTlVVPVgTgPfVsnnnsJ
        BsBsZHZNdWwsNdrzgCrMMqsjzzMC
        flfhVWFmLrhQzCCh
        fVbmFSpnSSmtnPZvdWbwvdvdHZ
        NsZWWWWLsBZPhfsLmPhcFCCHCMMrqfqcvHMfHH
        nThSllnplGlMpvFRcCqrrr
        DnTwSztgzlDnVGTwztmdZhmLdJdNDshBdsWs
        RBBGTFZGglMHvrtcgSdnNgjg
        DmVcbmbJmwJDJzVVwzJfmfstnztvjnNjvNSpdptvzCnpjj
        DsLcfLmbhVQssQJQscWRPBZZMMRLHFHZBGMG
        FVvhVnhFnFhmvFhVcMBHLgcPClrqqrtqCppldrRRTppldg
        QLWfDNwsQLtlrrCtDdpq
        sJwZwLsGJWGGwzzWZNbWNLjQHSVhvHSnhcMFcbVmnvcchSBS
        jTMNMrHBJWWDffRqfDBqfD
        QmSFphtQqQmVmqVnPnPlpwgfnRnDPl
        VqFmLFbLhmZhGFGmCmGtZLtJWzWHcJrNrHMccjMscMHzMZ
        hGPGmbfPzbPfgdMdWGqBGQcqpp
        nvFTvDrTdNZZlrjnMHHHpBBcppqq
        rNlZZNLvRdRCRFFwZwhgbmSJPSmPfhfwhS
        vjdbFWTtFRRvtvZZvdWJWbGjLhCcnrrrNqLNCPqchShNqc
        QHQVlDsMfmmDMHDBdLdCSLnhNLNNfqCd
        VQHsMDpHlzMBBwlsmMzmmlVwptvTWdvJdbvJtRTWgGFJJGtR
        nSScBcnbbFSQVdBFBtWpwtvtPbTZthtTvT
        pRzHpGjCDGzHGCGsThqqwZwPhCtvhTqZ
        NzlzjDDpNldBFrlfFQ
        qJlDlPPWppgppqPlplpfdvgnbMfGbdgCghMdCM
        QWTWZcSsWbvVvTnhfC
        tRFLwZrcrWzzlJmtBqlm
        HMNMvvzzNcmfNmfbhs
        qVcwCgjCLtWRSLsTPbmPfmTh
        RtWCJgddWRtCJdWWgdBjwWWwpzMFpHGprcBGFFnGHQZHQGpF
        gZgBDgDVGDGjmDZRtgjvVvtQdnLrcRcrdfdfCcnlscsJsn
        WTqzqHqNzpHpwzNhMHNwWPbQCQcCLsnCrLLfcrffNflcNn
        zHTwwpTPzTTwlFTFzwqzPbwZGgGZZBtmGGvGmBGZVFStFZ
        znlSSzfzTcmmfcCt
        PHWWGpqgPShPMwGwqJFTVtwtCVTCmTJcFc
        qHqqSggLrRLBbvDDdndzRQ
        WBddBQWZWWQqqQFMWfmrWsJnmVJJNDDVJGsLmHmLDN
        PTgCjvCCPPPzSZGJVLsVZCHHnH
        pzwtPTvzTjRTPtwSjPSzRgBbWMBfMwwZfbWrMrZFqFFM
        BqDwVqdqlDlblQMf
        ZcCWWcWzvJZjcPjZZZfTHfQJQHThqpMbQQJf
        LPCcZcczZLgCjvPWgvstjsjmRRBdmGrdGdmSFGnFrtGmqr
        CBvgQssVzfCBQSgvvvfmrlGrCtMGwthJlJtbrh
        TpLqLRFpqdRpRTfNPtRmrMMtMlMMmlMJlt
        PZTjqFFTHZZNZpqcVWzVvgzcWnSWfBDD
        SVSTpgpVpdNbpcVdfjcNfbcJnqsltcJPvRJqRwQqlQsJls
        zhWzDLmFHhmrWZmmzHJJQlnswqsvttrstQqs
        zGtZFGGCmZmGGFhLBWBGGFdgVjgppMTSTgMfCNfVVSdj
        CzjNJGcnzQJltPHttcPHTP
        bLVsqLbLmSSVrqmdhVSmsVFFprfrFWrwTTWWWZpFPtlP
        ssDsMqLqhvmvhdmdvzRCnQgRzzBjgnlNCM
        TzTLzzSGRlRSjWzlWRzHGTpNhPhJPmdnNPPbhlbPbdhfPh
        mBCDBVrCqVQvQMBcVcqBrBDsbtJfnZNbJndNNhthZNJfPZPs
        wMCrqVvBzmzHTGLw
        NbfwfZPPdVNPdBdQBcmQzrQz
        nnWqHLWGFMDFDLDjsqnHLsrQGzmJczmQrgJmJGZmQrgJ
        FFWRsHMHCZCWFwRwphpvlfTTpp
        PclPlVZvLDNvVZSLSMvvDttmtfzFtzHqtqtzzccCFc
        jrggQGhjQsTDbrbJjJQqzzCsdtzzFCdHqmBBHz
        WGDgngwrQggZMNvMWPMRRV
        wNgpMdMMcdSscccNcLLTbtQJtQJQltJwFtlBlzBt
        HHGhrLrCvHWHCPhrWDtnBllnQbfQftGnfnBF
        HvLjWCLHPZvHHHZjjrqVTTZVcppMgNNNNSpS
        QQrwQmvWQjgTfvBjfffrSDcrqSqDDVLctqqcVd
        GnHFnGhGplGMlHMNhzBzlLPLVcVNCPDqVNdcqLdqtV
        GnMGpslMhGsRzzHzGsZFZQJTTmWfBbvfgfgJRfbwbW
        MRCtSwMhvjCGtvMZDVWpVZJlVccNDlpb
        gdLQFFwwLfHJWnQlcJJbWc
        rdqdmqHLTLmsswsFHLFtMPRMCSSRtSjTPMPSCR
        jmCCnLCLZjZjRjQTLZQhGPGhhzHhDRGRDzwzwh
        stlJlrlJJcSSfSMMzPfhhGhzpwhpNwhD
        rbrbBcSlWmdZWjDnTm
        PNBRNnnqQRNfVfRtVVzgFLLttpSwgzzzmFFF
        fcWlcbvvCFzLbwLw
        rlrMrhTJhDcTTfhRNqHRQPQRQNQB
        TrprpprRVVfpRpVqTVpzDdvmvbbCchhcttqcthSMdd
        JlnZnFlsMBZnJHlsLsCLbSNtbNhdbbShCScm
        FlZjjsHHsnQFQwTDzMRRpGRR
        wHWzwCTTqJhzzvJhWHWhqJWrFsFQrrrFCfFfgjjgjprfsp
        DBRmZRtZLbnRBGSBmtGSLpjBrrsfrgsTQVrVrrPrgr
        DLnbcbtLtmNNmbRcGbcGmHzlThNNhqJTHdvqvWlHJh
        GSNqjRcqflNLnCTTWrWn
        BmwQtmtJwPwmzMwQtHtVssvrnpWTTnsTTgpVCLCs
        DBBQHJJrzhzQDDfSljRfhccfcdZf
        wtgtChCwzqgLzjggqtHtjFHHFcnPfdRDfZZVcPfVZZfGnfdm
        vBTrRTTWGGmcTDVD
        SJMbbpWslJblSSNzNsztRChzqRCj
        gBHHCtVCSHMQlfFTQqCfmq
        WrpdwjbwbwQGlPqSqblP
        wWDncWrDDNdWNRjScScjpzvHZtBMZtJsvLVgvzssBsvs
        VppWpVfmZPBlnmrGBzhttMzMpctLLcChSh
        FwgLJvRdHcwMzSzjzc
        QvbgdQLQgDvsqvqRHRDdDQDBWmBGBflnVbZmZmmnBBWrmW
        SqShwLFCQGpDHCtZCWpW
        bdHPHjTbJdsMnPHPbdjgtnBlVlBnVgtZpDBpWV
        bdmPcjbjMNMvvHbTcQRNfRwRwLffwwqwNF
        zdRHTpQTQHQnpnnQRHTsNNlJSJWmzJmJllNmSG
        FBbRvLbFRwLqbbVgBVqqLFqJtJNcltsSGmgmGtNtgWmstm
        FLhhfvvVwvjqfLRBqLVqbwqZQrTTpHMHjdrpnnDPDQCdCrpC
        JgjzvbJCWgbjgGbJWjRhgNPGHHBMtqBStZZsHMSsBqtD
        cfQdwQFdQQppnVVnlFLLBsBZMhqPlPMMqBSHDtHM
        wnQhcnVddmdWgjvjmvRjjJ
        QpcRtndvsLcVJtRSzWSlWjzSbjjWBv
        qGZPqCTmGPqgGTCqHgCqZCPFWbbBNBMNBbdBMlWWrbjlMbFl
        qhHDGhCmPhZHgDmDVQthttRchLwLdwcc
        srpPMwlMmsrGFGswvDRhRWRDJJJchJ
        fSgBbCBNnBTTgCNLTCRJhRJVWhTcVVVFFJdR
        SbBnnLNZCLFQCZjnCnZFjPrzqmlMmmsrpzrlsmtt
        BBsfDfsBDSWRwlLqmWCpWcllrl
        nQMgMnnnhdntgMBrCdpNNLNlNqLqLl
        FnQFHzPQJjJGRBGvfR
        lRnVRFFlgMCRVwLgFZRnZQHWdcftHdmcJHmmMdzzfz
        DGBqGQbhhBDbSBpGDBzqdNHJdtmcWdqdmtcm
        bjbsBvjhSlVsPRgLQl
        dDLbRdTMRJMbFRzZBfzNSjtNBzBD
        PmgspqqVrppTVrvrsPhhfQwZBwNjNtNffzqqfwwN
        mCcmsngrPvpVTssCVsvsPLRRJllGFlnRGbMJMWWlJJ
        fGlGZHRRbwgPbZRRNCdcSWpncnQtQWlWcWpW
        JrTLJgVvVLQQvtSvQncQ
        JrrrmMTBVTmjBMrVjrshmJzgCfzRPCRZPGHfbwNPzbZHNH
        qqqlDDZzVVnNqHDDFFFNlQpzjrTvsvzTbgJQQggjJp
        cWPWcCmMfCMWdtPMhMbQQQjGGjpdvjTbjgjr
        WtMSBCtCwchChMfBWtcPnNVNqZZLDRNqTRnnlwHn
        mvQQnhBvhmvBmncmZBclTZTQccRFNFFdqFFgVqSRrgFrppNR
        MjzJPzGPfffMCjVVjfPHLCFRNFStqrdRSdqdNGRqNptq
        HDJHPjDJLfjbzfwPjCzCWWTwlmQhBnsWBvVsvBvZ
        RVjcshhscQhrVjhvzjVfDNnzGtftmDHFttFGGf
        qLcBCCMBJJbTdBDnNtdfnmDG
        WpZgLLclTclRwgjgsrwsvj
        shhhltNPcDtlNcNMcsctNtppLZvWWFLTFFZpTZDQgFLT
        dRgJVzRHbqnLpTWQvLLJfp
        mCVCdzqHndbqHCrVqRrmbwtNBsmPwNmScPgtPhBclw
        bDDZMDrFPsrsMcsrbJZJdMMGpSzpSbwRSSRGpCHCGzlhCC
        BWWNQjBLQVHhlGpSCmwj
        ffwnNwfgtnNgVVwfNWBWnFsMJTJTcPFJcTFDsrJstJ
        vQbQLQBpBvbvpHplHNTHWGZDngntZCQGgZhGhtjG
        rqccPPmcrffRmsmCjVgnrGChChDjgW
        fqRJsJMSlSzSWTbT
        brsjjJPJwrJJsrRRlllNQGWQpwppCtfGGtWzGGMQ
        ncBqqLTDnmLgVDZVnBDmdtVVtMzWWdMCQdpQWdVz
        hDZgTSSnTzNPNFSFPF
        VZVJJtWTsfTVVWsJhPWrCjzSBJlHSmjJCRlNSSlz
        CqMpwccgvvgLnvLbMMRRjBNHzjmGmwNHlmlN
        gLqqvpCDfVDrTfVW
        CNMDGNPPNJCGbLnTffsTLT
        tcBBRlrBdQrtmtWFjjbnrTjjFbjr
        cTQQhcmvcBRcwDMVDZZPPCJh
        mBCdgPLgZmLfGmfvGhtRQJWjtjQGQhtN
        pMwrVwbwHMsqcTWQhQWzggTTWp
        nnSMwrlrsmSZgvvmDd
        WNSzpCzNzqzNdmqrRHrrLHFrJH
        MtPfvnGMPnMcbnRtDHTRFFDrmJRQ
        PcBsfPPHPGGfcSzZjNjpNZZdCs
        mDCZVLDhWVSDCRvGtsGgGRHl
        JjPwPNdcPnjPdcwNltHzzGmgGJzQJJRQ
        dqfjnNmwmbmWrZMbMrThhB
        qtBpNZFpBGFNfZNPmZPmQmHrmPPPTz
        LLwJLvDvlWWLHdwDrVcCRcDVzzVVcV
        sMMwvgjnMvjvnlsvNFBqfGHFqHGjtSpS
        MmZZsFgwJTdTMdgmZdZRgFhDHhPQPPnRPhCrHhnnrPDD
        fBcLlNNpQCDLDJJC
        jSbWWlWpBpclWlWpNWlVBbWVdgwswFJmFJsGtdMggZFGbZwd
        CMVQVMLLMFGRCMWQttnqqwQwhqsm
        pJzlczSpPpPgmsqNhmPGDstq
        gZgTccZGGpzdpjclGRVMVRFRMFvHRLRdLf
        FMWMSBtStZqZWQtFtScWWSZmHPVJJVHwwlTgmgbzQwbwTJ
        jhGLhdjNjsLvLsshzHJPVdVmmbzHzdHJ
        jvDRNjnDNGRCzjLzZZpqnrFBSccWrMcB
        zggmthDDghHvtrdgrVWfSBRwTHLWHwsBWw
        PGGjpCjQnJQGJcJnnQpjFWVSsZWVLRZLBcsWSZBRWS
        FGQlpnJCbqqGGRCjjnlCqGMtdNmmmvdNmmmzvhbrmgMz
        TstvBTdgBhqTsdTcPlfCSrNMrNnrCNNSNNgp
        HwLQwQDZzDjnDbmMhNSnmm
        FZLVzLLQHRRzwWHjdPlJctlJtlsllhRs
        fBtPsMDDswHvBmmVdBlSBRcGGnhVhg
        LWJbrpFqpTLTTjqqNWlhnRGGSnhrcSdlRlsh
        JWNbbpjJzTbNNNJNJMvmvfZHvzDsHDCsZw
        LPGnPNLtwGhFFnJPfsqpVVszzpsP
        TcWdvlrcWddggrDBDDdDMmWzRJqfVQZqmsfZsRQzZfZzQJ
        TldWrMrDdlDCDdMTcwSLVCSShLNSwHjhGF
        JGsWWWQsJmPwQWbBPmccbcbqFfMMpFDVCDFVFVCDqqfFwD
        ZtLnlvLnNtvLndnCmfMVSmVCClfpVp
        zTzZtjnZNLNmZvdtznntHHZJbBRGBRQWcJGbGsbsJRPQWT
        MLmlMTPtQtMNlhbqbbqhflBB
        rcrvjpSvScbRbBvbDBPG
        ZZJzSHpzPrJzHFmMVMFmHCLNtV
        """;
	char[] ranks = { 'a', 'b','c','d','e','f','g','h','i','j','k','l','m','n','o',
'p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

	[Benchmark]
	public int MehdiSolution()
	{
		int result = 0;
		foreach (var element in Input.Split("\n"))
		{

			var firstPart = string.Join("", element.Substring(0, element.Length / 2).Distinct());
			var secondPart = string.Join("", element.Substring(element.Length / 2, element.Length / 2).Distinct());
			for (int i = 0; i < firstPart.Length; i++)
			{

				if (secondPart.Contains(firstPart[i]))
				{
					result += Array.IndexOf(ranks, firstPart[i]) + 1;
				}
			}
		}
		
		return result;
	}

    [Benchmark]
    public int MarcinSolution()
    {
		int result = 0;
		int startIdx = 0;
		ulong bitmap = 0;

		for (int i = 0; i <= Input.Length; i++)
		{
			if (i == Input.Length || Input[i] == 0x0D)
			{
				int midIdx = startIdx + ((i - startIdx) / 2);
				for (int j = i - 1; j >= startIdx; j--)
				{
					char c = Input[j];
					int w = c >= 'a' && c <= 'z' ? 26 - ('z' - c) : 26 + (26 - ('Z' - c));

					if (j >= midIdx)
					{
						bitmap |= 1UL << w;
					}
					else if ((bitmap & (ulong)(1UL << w)) != 0)
					{
						result += w;
						break;

					}
				}

				i += 2;
				startIdx = i;
				bitmap = 0;
			}
		}

		return result;
	}
}
