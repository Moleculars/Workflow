using System;

namespace Bb.Workflow.Models
{
    public class Event : ISourceEvent
    {

        /// <summary>
        /// Clef qui définit le type d'evenement
        /// </summary>
        public string Key { get; set; }


        public string Operand { get; set; }

        /// <summary>
        /// Clef du colis
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Clef unique de l'évènement
        /// </summary>
        public Guid Uid { get; set; }

    }

}
