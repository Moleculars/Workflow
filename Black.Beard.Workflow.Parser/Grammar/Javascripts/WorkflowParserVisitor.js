// Generated from WorkflowParser.g4 by ANTLR 4.7
// jshint ignore: start
var antlr4 = require('antlr4/index');

// This class defines a complete generic visitor for a parse tree produced by WorkflowParser.

function WorkflowParserVisitor() {
	antlr4.tree.ParseTreeVisitor.call(this);
	return this;
}

WorkflowParserVisitor.prototype = Object.create(antlr4.tree.ParseTreeVisitor.prototype);
WorkflowParserVisitor.prototype.constructor = WorkflowParserVisitor;

// Visit a parse tree produced by WorkflowParser#script.
WorkflowParserVisitor.prototype.visitScript = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#matchings.
WorkflowParserVisitor.prototype.visitMatchings = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#matching.
WorkflowParserVisitor.prototype.visitMatching = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#unit_statement.
WorkflowParserVisitor.prototype.visitUnit_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#define_statement.
WorkflowParserVisitor.prototype.visitDefine_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#constant.
WorkflowParserVisitor.prototype.visitConstant = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#value.
WorkflowParserVisitor.prototype.visitValue = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#sequence_statement.
WorkflowParserVisitor.prototype.visitSequence_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#state.
WorkflowParserVisitor.prototype.visitState = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#on_event_statement.
WorkflowParserVisitor.prototype.visitOn_event_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#delay.
WorkflowParserVisitor.prototype.visitDelay = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#switch_state.
WorkflowParserVisitor.prototype.visitSwitch_state = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#execute.
WorkflowParserVisitor.prototype.visitExecute = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#execute2.
WorkflowParserVisitor.prototype.visitExecute2 = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#actions.
WorkflowParserVisitor.prototype.visitActions = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#action.
WorkflowParserVisitor.prototype.visitAction = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#arguments.
WorkflowParserVisitor.prototype.visitArguments = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#rule_condition.
WorkflowParserVisitor.prototype.visitRule_condition = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#action_statement.
WorkflowParserVisitor.prototype.visitAction_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#rule_statement.
WorkflowParserVisitor.prototype.visitRule_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#event_statement.
WorkflowParserVisitor.prototype.visitEvent_statement = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#number.
WorkflowParserVisitor.prototype.visitNumber = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#key.
WorkflowParserVisitor.prototype.visitKey = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#comment.
WorkflowParserVisitor.prototype.visitComment = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#numeric.
WorkflowParserVisitor.prototype.visitNumeric = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#numbers.
WorkflowParserVisitor.prototype.visitNumbers = function(ctx) {
  return this.visitChildren(ctx);
};


// Visit a parse tree produced by WorkflowParser#string.
WorkflowParserVisitor.prototype.visitString = function(ctx) {
  return this.visitChildren(ctx);
};



exports.WorkflowParserVisitor = WorkflowParserVisitor;