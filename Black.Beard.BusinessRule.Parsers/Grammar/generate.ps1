# antlr-4.7-complete.jar must be preset 
# http://www.antlr.org/download/antlr-4.7-complete.jar

java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp BusinessRuleLexer.g4 -visitor -no-listener -package Pssa.BusinessRule.Parser
java.exe -jar antlr-4.7-complete.jar -Dlanguage=CSharp BusinessRuleParser.g4 -visitor -no-listener -package Pssa.BusinessRule.Parser