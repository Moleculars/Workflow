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

parser grammar BusinessRuleParser;

options { 
    // memoize=True;
    tokenVocab=BusinessRuleLexer; 
    }

script :
    NAME identifier 
    (DESCRIPTION comment)?

    // (INCLUDE CHAR_STRING)*
    EVENT CHAR_STRING
    (MATCHING matchings+)? 

    declare_constants?

	(unit_statement SEMICOLON)* EOF
    ;

declare_constants :
    DECLARE declare_constant+
    ;

declare_constant : 
    CONST identifier EQUAL constant comment
    ;

matchings : 
    LEFT_PAREN matching RIGHT_PAREN (COMMA LEFT_PAREN matching RIGHT_PAREN)*
    ;

matching : 
    identifier EQUAL CHAR_STRING
    ;

unit_statement :
	  rule
    | load_data
//    | function
    ;

load_data : 
    LOAD DATA identifier LEFT_PAREN arguments? RIGHT_PAREN
    ;

function :
    FUNCTION identifier LEFT_PAREN parameters? RIGHT_PAREN
    ;

parameters :
    parameter (COMMA parameter)*
    ;

parameter :
    identifier
    ;

rule :
    WHEN expre_action thenResult=result+ (ELSE elseRule=rule)?
    ;

result : 
    RETURN EVENT identifier identifier
    ;

action : 
    identifier LEFT_PAREN arguments? RIGHT_PAREN
    ;

expre : 
      constant
    | identifiers
    ;

expre_action :
      not1=NOT? action (operator=(AND | ANDALSO | OR | XOR) not2=NOT? exp2=expre_action)?
    | not1=NOT? LEFT_PAREN exp1=expre_action RIGHT_PAREN (operator=(AND | ANDALSO | OR | XOR) not2=NOT? exp2=expre_action)?
    ;

arguments : argument (COMMA argument)*;

argument : 
    expre
    ;

operation : 
      PLUS 
    | MINUS 
    | TIME 
    | DIVID
    | MODULO
    | POWER
    ;

comparer : 
      EQUAL 
    | NOT_EQUAL
    | GREATER 
    | GREATER_OR_EQUAL 
    | LESS 
    | LESS_OR_EQUAL
    ;

identifiers : identifier (DOT identifier)*;
identifier : CHAR_STRING | REGULAR_ID;
comment : CHAR_COMMENT;

constant : 
      number 
    | number operation number 
    | number comparer number 
    | string (PLUS string)*
    ;

number : integer | float;
integer : (PLUS|MINUS)? NUMBER delay?;
float : (PLUS|MINUS)? NUMBER (COMMA NUMBER)?;

delay : MINUTE | HOUR | DAY;

string :
	CHAR_STRING
    ;




