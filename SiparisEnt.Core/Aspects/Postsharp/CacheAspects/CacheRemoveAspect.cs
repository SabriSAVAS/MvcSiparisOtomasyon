using PostSharp.Aspects;
using SiparisEnt.Core.CrossCuttingConcerns.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private string _pattern;
        private Type _cachetype;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(Type cachetype)
        {
            _cachetype = cachetype;
        }
        public CacheRemoveAspect(string pattern,Type cachetype)
        {
            _pattern = pattern;
            _cachetype = cachetype;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cachetype) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);
            base.RuntimeInitialize(method);
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ?
                string.Format("{0}.{1}.*", args.Method.ReflectedType.Namespace, args.Method.Name) :
                _pattern);
        }


    }
}
