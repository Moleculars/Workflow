//using System;
//using System.Collections.Generic;
//using Pssa.Routing.Entities;
//using Pssa.Routing.Services.Core.Audits;

//namespace Pssa.Routing.Services.Core.Chain
//{
//    public class ReferenceData
//    {
//        /// <summary>
//        /// Ponderations
//        /// </summary>
//        public Dictionary<DayOfWeek, decimal> Ponderations { get; set; }

//        /// <summary>
//        /// Updated Pudos since last call
//        /// </summary>
//        public IEnumerable<Pudo> ReferencialSites { get; set; }

//        /// <summary>
//        /// Contient les données partagée entre les differentes
//        /// </summary>
//        public RoutingQueue RoutingQueue { get; set; }

//        /// <summary>
//        /// Données de référrences des priorites par carrier
//        /// </summary>
//        public IEnumerable<CarrierPriorityConfiguration> CarrierPriorityConfig { get; set; }

//        /// <summary>
//        /// Données de reference des priorités de casier pour le calcul de l'affectation des casiers theoriques
//        /// </summary>
//        public IEnumerable<int> LockerOrderPriorityConfig { get; set; }
        
//        /// <summary>
//        /// Données de configuration Shipper rerouting
//        /// </summary>
//        public IEnumerable<ShipperGroupRerouting> ShipperReroutingConfig { get; set; }

//        /// <summary>
//        /// Données de référence hors norme pudo
//        /// </summary>
//        public HorsNormePudoConfiguration HorsNormePudoConfig { get; set; }

//        public IEnumerable<CarriersByCountryConfiguration> CarrierCountryConfig { get; set; }

//        /// <summary>
//        /// Carrier CutOff
//        /// </summary>
//        public IEnumerable<CarrierCutOffConfiguration> CarrierCutOff;

//        /// <summary>
//        /// Audit Global du batch
//        /// </summary>
//        public AuditRouting AuditRouting { get; set; }

//        /// <summary>
//        /// Indiquer s'il y a eu une erreur d'execution du batch
//        /// </summary>
//        public bool ErrorBatch { get; set; }
//    }
//}
