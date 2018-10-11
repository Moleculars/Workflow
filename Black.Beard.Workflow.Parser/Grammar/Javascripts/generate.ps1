# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar

java.exe -jar antlr-4.7-complete.jar -Dlanguage=JavaScript WorkflowLexer.g4 -visitor -no-listener -package Pssa.Workflow.Parser
java.exe -jar antlr-4.7-complete.jar -Dlanguage=JavaScript WorkflowParser.g4 -visitor -no-listener -package Pssa.Workflow.Parser
