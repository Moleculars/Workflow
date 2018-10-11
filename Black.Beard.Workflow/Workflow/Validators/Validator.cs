using System;

namespace Bb.Workflow.Validators
{

    public abstract class Validator<T>
    {

        private readonly Validator<T> _child;

        public Validator(Validator<T> child = null)
        {
            this._child = child;
        }

        public void Validate(T item)
        {

            if (item == null)
                throw new NullReferenceException(nameof(item));

            Validate_Impl(item);

            if (this._child != null)
                this._child.Validate_Impl(item);

        }

        protected abstract void Validate_Impl(T @event);

    }

}
