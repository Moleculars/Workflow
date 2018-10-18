using Bb.Core;
using Bb.Workflow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Workflow.Validators
{

    public abstract class EventValidator<TEvent> : Validator<TEvent> where TEvent : ISourceEvent
    {

        public EventValidator(Validator<TEvent> child = null) : base(child)
        {

        }

    }

}
