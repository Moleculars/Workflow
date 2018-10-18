using Bb.Core;
using Bb.Workflow.Configurations;
using Bb.Workflow.Models;
using Bb.Workflow.Parser;
using Bb.Workflow.Parser.Grammar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Black.Beard.Workflow.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            string rules = @"

NAME 'test'
DESCRIPTION ""workflow de test""

-- Definition de la liste exaustives de évènements
DEFINE EVENT Event_changed 	""Le colis a changé d'étape"";

-- Definition de la liste exaustives de règles
DEFINE RULE BR_Have_True    ""Le destinataire a une addresse email"";

-- Definition de la liste exaustives de actions
DEFINE ACTION Act_Push 		""Envoi au Pda"";

-- Liste des états par séquence			
DEFINE SEQUENCE 'Creation1' ""Description phase 1"" 
    WITH STATE State_Initialization_Workflow ""Création workflow""					
        NO EVENT SWITCH State_2
	;
	
DEFINE SEQUENCE 'Scan_Pda' ""Scan pda""
    WITH STATE State_2 ""Waiting"" 
        ON ENTER EXECUTE(Act_Push())
        
        ON EVENT Event_changed 
            WHEN BR_Have_True SWITCH State_Waiting_Closed_Ok
            SWITCH State_close_ko

        WAITING 1 DAY BEFORE
            SWITCH State_close_ko
	;
						
DEFINE SEQUENCE 'End' ""End""
    WITH FINAL STATE State_close_ko     ""litigation""	
	
    WITH FINAL STATE State_Ok           ""Ok""	
    
;";


            var parser = WorkflowConfigParser.ParseString(new System.Text.StringBuilder(rules));
            var visitor = new ConfigConverterWorkflowVisitor();
            var workflowConfig = (WorkflowDefinitionModel)parser.Visit(visitor);


            ProcessorWorkflow<Context> workflow = new ProcessorWorkflow<Context>(workflowConfig);

        }

    }


        public class Context : IWorkflowContext
    {

        public ISourceEvent SourceEvent { get; set; }

        public IWorkflowState Workflow { get; set; }

        public List<PushedAction> ActionToExecutes => throw new System.NotImplementedException();

    }

}
