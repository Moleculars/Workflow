/**
 * workflow engine Parser
 *
 * Copyright (c) 2009-2011 Gael beard <g.beard@pickup-services.com>
 * Copyright (c) 2015-2017 Ivan Kochurkin (KvanTTT, kvanttt@gmail.com, Positive Technologies).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

parser grammar WorkflowParser;

options { 
    // memoize=True;
    tokenVocab=WorkflowLexer; 
    }

script :
    NAME key 
    (DESCRIPTION comment)?
    (INCLUDE CHAR_STRING)*
    (MATCHING matchings+)? 
	(unit_statement SEMICOLON)* EOF
    ;

matchings : 
    LEFT_PAREN matching RIGHT_PAREN (COMMA LEFT_PAREN matching RIGHT_PAREN)*
    ;

matching : 
    key EQUAL CHAR_STRING
    ;

unit_statement :
	  define_statement
    ;

define_statement :
	DEFINE
    (  
        event_statement 
      | rule_statement
      | action_statement
      | constant
      | sequence_statement
    )    
    ;

constant :
    CONST key value comment
    ;

value :
    string | numbers | delay | REGULAR_ID
    ;

sequence_statement :
    SEQUENCE key comment
    state+
    ;

state :
    WITH (INITIAL | FINAL)? STATE key comment
    execute*
    on_event_statement*
    ;

on_event_statement :
    (NO EVENT | ON EVENT key | AFTER delay) switch_state+
    ;    

delay :
    number (MINUTE | HOUR | DAY)
    ;

switch_state :
    (WHEN rule_condition)?
    (
          execute2* (WAITING delay BEFORE)? SWITCH key
        | execute2+
    )
    ;

execute :
    ON (ENTER | EXIT | ENTER EXIT) EXECUTE LEFT_PAREN actions? RIGHT_PAREN
    ;

execute2 :
    (ON EXIT)? EXECUTE LEFT_PAREN actions? RIGHT_PAREN
    ;

actions :
    action (COMMA action)*
    ;

action : key LEFT_PAREN arguments? RIGHT_PAREN
    ;

arguments : 
    string (COMMA string)*
    ;

rule_condition :
      key
    | NOT rule_condition
    | rule_condition AND rule_condition
    | rule_condition OR rule_condition
    | LEFT_PAREN rule_condition RIGHT_PAREN
    ;

action_statement :
    ACTION key comment
    ;

rule_statement :
    RULE key comment
    ;

event_statement :
    NO? EVENT key comment
    ;

number : NUMBER;

key : CHAR_STRING | REGULAR_ID;
comment : CHAR_COMMENT;

numeric :
    numbers (DOT numbers)
    ;

numbers :
    NUMBER*
    ;

string :
	CHAR_STRING
    ;




