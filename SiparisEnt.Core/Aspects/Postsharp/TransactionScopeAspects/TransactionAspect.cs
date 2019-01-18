using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using PostSharp.Aspects;

namespace SiparisEnt.Core.Aspects.Postsharp.TransactionScopeAspects
{
    [Serializable]
   public class TransactionAspect:OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;

        public TransactionAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionAspect()
        {
                
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag=new TransactionAspect(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            ((TransactionScope)(args.MethodExecutionTag)).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ((TransactionScope)(args.MethodExecutionTag)).Dispose();
        }
    }
}
