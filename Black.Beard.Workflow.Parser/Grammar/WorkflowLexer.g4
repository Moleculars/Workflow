/**
 * Oracle(c) PL/SQL 11g Parser
 *
 * Copyright (c) 2009-2011 Alexandre Porcelli <alexandre.porcelli@gmail.com>
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

lexer grammar WorkflowLexer;

ACTION :    'ACTION';
AFTER :     'AFTER';
AND :       'AND';

BEFORE :    'BEFORE';

CONST :     'CONST';
DESCRIPTION : 'DESCRIPTION';
DAY :       'DAY';
DEFINE :    'DEFINE';

EVENT :     'EVENT';
EXECUTE :   'EXECUTE';
ENTER :     'ENTER';
EQUAL :     '=';
EXIT  :     'EXIT';

FINAL :     'FINAL';
HOUR :      'HOUR';

INCLUDE :   'INCLUDE';
INITIAL :   'INITIAL';

MATCHING :  'MATCHING';
MINUTE :    'MINUTE';

NAME :      'NAME';

NO :        'NO';
NOT :       'NOT';

ON :        'ON';
OR :        'OR';

PARAMETER : 'PARAMETER';

RULE :      'RULE';

SWITCH :    'SWITCH';
SEQUENCE :  'SEQUENCE';
STATE :     'STATE';

TIME :      'TIME';

WAITING :   'WAITING';
WITH :      'WITH';
WHEN :      'WHEN';


// and a superfluous subtoken typecasting of the "QUOTE"
CHAR_STRING:  '\'' (~('\'' | '\r' | '\n') | '\'\'' | NEWLINE)+ '\'';
CHAR_COMMENT: '"' (~('"' | '\r' | '\n') | '""' | NEWLINE)* '"';

// SQL_SPECIAL_CHAR was split into single rules
LEFT_PAREN:             '(';
RIGHT_PAREN:            ')';
SEMICOLON :             ';';
COMMA :                 ',';
DOT :                   '.';
SPACES: [ \t\r\n]+ -> skip;
    
// Rule #504 <SIMPLE_LETTER> - simple_latin _letter was generalised into SIMPLE_LETTER
//  Unicode is yet to be implemented - see NSF0
fragment
SIMPLE_LETTER
    : [A-Za-z]
    ;

NUMBER
    : [0-9]+
    ;

// Rule #097 <COMMENT>
SINGLE_LINE_COMMENT: '--' ~('\r' | '\n')* (NEWLINE | EOF)   -> channel(HIDDEN);
MULTI_LINE_COMMENT:  '/*' .*? '*/'                          -> channel(HIDDEN);

// SQL*Plus prompt
// TODO should be grammar rule, but tricky to implement

fragment
NEWLINE: '\r'? '\n';
    
fragment
SPACE: [ \t];

REGULAR_ID: SIMPLE_LETTER (SIMPLE_LETTER | '$' | '_' | '#' | [0-9])*;
