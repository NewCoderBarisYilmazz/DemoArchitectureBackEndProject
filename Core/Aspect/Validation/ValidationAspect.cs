using Castle.DynamicProxy;
using Core.Interceptors;
using Core.ValidationTools;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private readonly Type _validator;

        public ValidationAspect(Type validator)
        {
            _validator = validator;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator=(IValidator)Activator.CreateInstance((_validator));
            var entityType=_validator.BaseType.GetGenericArguments()[0]; //entity aldık generic argümanalrı entity veriyor
            var entities=invocation.Arguments.Where(t=>t.GetType() == entityType).ToList();
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }
    }
}
