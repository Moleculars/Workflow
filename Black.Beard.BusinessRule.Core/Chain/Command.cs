using System;

namespace Pssa.Routing.Services.Core.Chain
{
    /// <summary>
    /// Class to define the chossen chaine of responsability 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T>
    {
        #region Ctro
        public Command(string name, bool enabled, Func<T, bool> func)
        {
            Name = name;
            _enabled = enabled;
            _func = func;
        }

        #endregion


        #region Private Methods
        public virtual bool Evaluate(T item)
        {
            if (_enabled)
                return _func(item);
            else
                return true;
        }
        #endregion

        #region public propreties

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        #endregion

        #region Private Fields
        /// <summary>
        /// the rule state
        /// </summary>
        private readonly bool _enabled;

        /// <summary>
        /// The _func
        /// </summary>
        private readonly Func<T, bool> _func;

        #endregion
    }
}