// Generated from c:\Users\g.beard\Desktop\anomalies\Pssa.Workflow.Parser\Grammar\Javascripts\WorkflowParser.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class WorkflowParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		ACTION=1, AFTER=2, AND=3, BEFORE=4, CONST=5, DESCRIPTION=6, DAY=7, DEFINE=8, 
		EVENT=9, EXECUTE=10, ENTER=11, EQUAL=12, EXIT=13, FINAL=14, HOUR=15, INCLUDE=16, 
		INITIAL=17, MATCHING=18, MINUTE=19, NAME=20, NO=21, NOT=22, ON=23, OR=24, 
		PARAMETER=25, RULE=26, SWITCH=27, SEQUENCE=28, STATE=29, TIME=30, WAITING=31, 
		WITH=32, WHEN=33, CHAR_STRING=34, CHAR_COMMENT=35, LEFT_PAREN=36, RIGHT_PAREN=37, 
		SEMICOLON=38, COMMA=39, DOT=40, SPACES=41, NUMBER=42, SINGLE_LINE_COMMENT=43, 
		MULTI_LINE_COMMENT=44, REGULAR_ID=45;
	public static final int
		RULE_script = 0, RULE_matchings = 1, RULE_matching = 2, RULE_unit_statement = 3, 
		RULE_define_statement = 4, RULE_constant = 5, RULE_value = 6, RULE_sequence_statement = 7, 
		RULE_state = 8, RULE_on_event_statement = 9, RULE_delay = 10, RULE_switch_state = 11, 
		RULE_execute = 12, RULE_execute2 = 13, RULE_actions = 14, RULE_action = 15, 
		RULE_arguments = 16, RULE_rule_condition = 17, RULE_action_statement = 18, 
		RULE_rule_statement = 19, RULE_event_statement = 20, RULE_number = 21, 
		RULE_key = 22, RULE_comment = 23, RULE_numeric = 24, RULE_numbers = 25, 
		RULE_string = 26;
	public static final String[] ruleNames = {
		"script", "matchings", "matching", "unit_statement", "define_statement", 
		"constant", "value", "sequence_statement", "state", "on_event_statement", 
		"delay", "switch_state", "execute", "execute2", "actions", "action", "arguments", 
		"rule_condition", "action_statement", "rule_statement", "event_statement", 
		"number", "key", "comment", "numeric", "numbers", "string"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'ACTION'", "'AFTER'", "'AND'", "'BEFORE'", "'CONST'", "'DESCRIPTION'", 
		"'DAY'", "'DEFINE'", "'EVENT'", "'EXECUTE'", "'ENTER'", "'='", "'EXIT'", 
		"'FINAL'", "'HOUR'", "'INCLUDE'", "'INITIAL'", "'MATCHING'", "'MINUTE'", 
		"'NAME'", "'NO'", "'NOT'", "'ON'", "'OR'", "'PARAMETER'", "'RULE'", "'SWITCH'", 
		"'SEQUENCE'", "'STATE'", "'TIME'", "'WAITING'", "'WITH'", "'WHEN'", null, 
		null, "'('", "')'", "';'", "','", "'.'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "ACTION", "AFTER", "AND", "BEFORE", "CONST", "DESCRIPTION", "DAY", 
		"DEFINE", "EVENT", "EXECUTE", "ENTER", "EQUAL", "EXIT", "FINAL", "HOUR", 
		"INCLUDE", "INITIAL", "MATCHING", "MINUTE", "NAME", "NO", "NOT", "ON", 
		"OR", "PARAMETER", "RULE", "SWITCH", "SEQUENCE", "STATE", "TIME", "WAITING", 
		"WITH", "WHEN", "CHAR_STRING", "CHAR_COMMENT", "LEFT_PAREN", "RIGHT_PAREN", 
		"SEMICOLON", "COMMA", "DOT", "SPACES", "NUMBER", "SINGLE_LINE_COMMENT", 
		"MULTI_LINE_COMMENT", "REGULAR_ID"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "WorkflowParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public WorkflowParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ScriptContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(WorkflowParser.NAME, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode EOF() { return getToken(WorkflowParser.EOF, 0); }
		public TerminalNode DESCRIPTION() { return getToken(WorkflowParser.DESCRIPTION, 0); }
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public List<TerminalNode> INCLUDE() { return getTokens(WorkflowParser.INCLUDE); }
		public TerminalNode INCLUDE(int i) {
			return getToken(WorkflowParser.INCLUDE, i);
		}
		public List<TerminalNode> CHAR_STRING() { return getTokens(WorkflowParser.CHAR_STRING); }
		public TerminalNode CHAR_STRING(int i) {
			return getToken(WorkflowParser.CHAR_STRING, i);
		}
		public TerminalNode MATCHING() { return getToken(WorkflowParser.MATCHING, 0); }
		public List<Unit_statementContext> unit_statement() {
			return getRuleContexts(Unit_statementContext.class);
		}
		public Unit_statementContext unit_statement(int i) {
			return getRuleContext(Unit_statementContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(WorkflowParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(WorkflowParser.SEMICOLON, i);
		}
		public List<MatchingsContext> matchings() {
			return getRuleContexts(MatchingsContext.class);
		}
		public MatchingsContext matchings(int i) {
			return getRuleContext(MatchingsContext.class,i);
		}
		public ScriptContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_script; }
	}

	public final ScriptContext script() throws RecognitionException {
		ScriptContext _localctx = new ScriptContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_script);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(54);
			match(NAME);
			setState(55);
			key();
			setState(58);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==DESCRIPTION) {
				{
				setState(56);
				match(DESCRIPTION);
				setState(57);
				comment();
				}
			}

			setState(64);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==INCLUDE) {
				{
				{
				setState(60);
				match(INCLUDE);
				setState(61);
				match(CHAR_STRING);
				}
				}
				setState(66);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(73);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MATCHING) {
				{
				setState(67);
				match(MATCHING);
				setState(69); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(68);
					matchings();
					}
					}
					setState(71); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==LEFT_PAREN );
				}
			}

			setState(80);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==DEFINE) {
				{
				{
				setState(75);
				unit_statement();
				setState(76);
				match(SEMICOLON);
				}
				}
				setState(82);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(83);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MatchingsContext extends ParserRuleContext {
		public List<TerminalNode> LEFT_PAREN() { return getTokens(WorkflowParser.LEFT_PAREN); }
		public TerminalNode LEFT_PAREN(int i) {
			return getToken(WorkflowParser.LEFT_PAREN, i);
		}
		public List<MatchingContext> matching() {
			return getRuleContexts(MatchingContext.class);
		}
		public MatchingContext matching(int i) {
			return getRuleContext(MatchingContext.class,i);
		}
		public List<TerminalNode> RIGHT_PAREN() { return getTokens(WorkflowParser.RIGHT_PAREN); }
		public TerminalNode RIGHT_PAREN(int i) {
			return getToken(WorkflowParser.RIGHT_PAREN, i);
		}
		public List<TerminalNode> COMMA() { return getTokens(WorkflowParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(WorkflowParser.COMMA, i);
		}
		public MatchingsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_matchings; }
	}

	public final MatchingsContext matchings() throws RecognitionException {
		MatchingsContext _localctx = new MatchingsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_matchings);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(85);
			match(LEFT_PAREN);
			setState(86);
			matching();
			setState(87);
			match(RIGHT_PAREN);
			setState(95);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(88);
				match(COMMA);
				setState(89);
				match(LEFT_PAREN);
				setState(90);
				matching();
				setState(91);
				match(RIGHT_PAREN);
				}
				}
				setState(97);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MatchingContext extends ParserRuleContext {
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode EQUAL() { return getToken(WorkflowParser.EQUAL, 0); }
		public TerminalNode CHAR_STRING() { return getToken(WorkflowParser.CHAR_STRING, 0); }
		public MatchingContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_matching; }
	}

	public final MatchingContext matching() throws RecognitionException {
		MatchingContext _localctx = new MatchingContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_matching);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(98);
			key();
			setState(99);
			match(EQUAL);
			setState(100);
			match(CHAR_STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unit_statementContext extends ParserRuleContext {
		public Define_statementContext define_statement() {
			return getRuleContext(Define_statementContext.class,0);
		}
		public Unit_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unit_statement; }
	}

	public final Unit_statementContext unit_statement() throws RecognitionException {
		Unit_statementContext _localctx = new Unit_statementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_unit_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			define_statement();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Define_statementContext extends ParserRuleContext {
		public TerminalNode DEFINE() { return getToken(WorkflowParser.DEFINE, 0); }
		public Event_statementContext event_statement() {
			return getRuleContext(Event_statementContext.class,0);
		}
		public Rule_statementContext rule_statement() {
			return getRuleContext(Rule_statementContext.class,0);
		}
		public Action_statementContext action_statement() {
			return getRuleContext(Action_statementContext.class,0);
		}
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public Sequence_statementContext sequence_statement() {
			return getRuleContext(Sequence_statementContext.class,0);
		}
		public Define_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_define_statement; }
	}

	public final Define_statementContext define_statement() throws RecognitionException {
		Define_statementContext _localctx = new Define_statementContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_define_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(104);
			match(DEFINE);
			setState(110);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case EVENT:
			case NO:
				{
				setState(105);
				event_statement();
				}
				break;
			case RULE:
				{
				setState(106);
				rule_statement();
				}
				break;
			case ACTION:
				{
				setState(107);
				action_statement();
				}
				break;
			case CONST:
				{
				setState(108);
				constant();
				}
				break;
			case SEQUENCE:
				{
				setState(109);
				sequence_statement();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode CONST() { return getToken(WorkflowParser.CONST, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_constant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(112);
			match(CONST);
			setState(113);
			key();
			setState(114);
			value();
			setState(115);
			comment();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValueContext extends ParserRuleContext {
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public DelayContext delay() {
			return getRuleContext(DelayContext.class,0);
		}
		public TerminalNode REGULAR_ID() { return getToken(WorkflowParser.REGULAR_ID, 0); }
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_value);
		try {
			setState(121);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(117);
				string();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(118);
				numbers();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(119);
				delay();
				}
				break;
			case 4:
				enterOuterAlt(_localctx, 4);
				{
				setState(120);
				match(REGULAR_ID);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Sequence_statementContext extends ParserRuleContext {
		public TerminalNode SEQUENCE() { return getToken(WorkflowParser.SEQUENCE, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public List<StateContext> state() {
			return getRuleContexts(StateContext.class);
		}
		public StateContext state(int i) {
			return getRuleContext(StateContext.class,i);
		}
		public Sequence_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sequence_statement; }
	}

	public final Sequence_statementContext sequence_statement() throws RecognitionException {
		Sequence_statementContext _localctx = new Sequence_statementContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_sequence_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			match(SEQUENCE);
			setState(124);
			key();
			setState(125);
			comment();
			setState(127); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(126);
				state();
				}
				}
				setState(129); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==WITH );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StateContext extends ParserRuleContext {
		public TerminalNode WITH() { return getToken(WorkflowParser.WITH, 0); }
		public TerminalNode STATE() { return getToken(WorkflowParser.STATE, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public List<ExecuteContext> execute() {
			return getRuleContexts(ExecuteContext.class);
		}
		public ExecuteContext execute(int i) {
			return getRuleContext(ExecuteContext.class,i);
		}
		public List<On_event_statementContext> on_event_statement() {
			return getRuleContexts(On_event_statementContext.class);
		}
		public On_event_statementContext on_event_statement(int i) {
			return getRuleContext(On_event_statementContext.class,i);
		}
		public TerminalNode INITIAL() { return getToken(WorkflowParser.INITIAL, 0); }
		public TerminalNode FINAL() { return getToken(WorkflowParser.FINAL, 0); }
		public StateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_state; }
	}

	public final StateContext state() throws RecognitionException {
		StateContext _localctx = new StateContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_state);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(131);
			match(WITH);
			setState(133);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==FINAL || _la==INITIAL) {
				{
				setState(132);
				_la = _input.LA(1);
				if ( !(_la==FINAL || _la==INITIAL) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			setState(135);
			match(STATE);
			setState(136);
			key();
			setState(137);
			comment();
			setState(141);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(138);
					execute();
					}
					} 
				}
				setState(143);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,10,_ctx);
			}
			setState(147);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AFTER) | (1L << NO) | (1L << ON))) != 0)) {
				{
				{
				setState(144);
				on_event_statement();
				}
				}
				setState(149);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class On_event_statementContext extends ParserRuleContext {
		public TerminalNode NO() { return getToken(WorkflowParser.NO, 0); }
		public TerminalNode EVENT() { return getToken(WorkflowParser.EVENT, 0); }
		public TerminalNode ON() { return getToken(WorkflowParser.ON, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode AFTER() { return getToken(WorkflowParser.AFTER, 0); }
		public DelayContext delay() {
			return getRuleContext(DelayContext.class,0);
		}
		public List<Switch_stateContext> switch_state() {
			return getRuleContexts(Switch_stateContext.class);
		}
		public Switch_stateContext switch_state(int i) {
			return getRuleContext(Switch_stateContext.class,i);
		}
		public On_event_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_on_event_statement; }
	}

	public final On_event_statementContext on_event_statement() throws RecognitionException {
		On_event_statementContext _localctx = new On_event_statementContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_on_event_statement);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(157);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NO:
				{
				setState(150);
				match(NO);
				setState(151);
				match(EVENT);
				}
				break;
			case ON:
				{
				setState(152);
				match(ON);
				setState(153);
				match(EVENT);
				setState(154);
				key();
				}
				break;
			case AFTER:
				{
				setState(155);
				match(AFTER);
				setState(156);
				delay();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			setState(160); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(159);
					switch_state();
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(162); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,13,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DelayContext extends ParserRuleContext {
		public NumberContext number() {
			return getRuleContext(NumberContext.class,0);
		}
		public TerminalNode MINUTE() { return getToken(WorkflowParser.MINUTE, 0); }
		public TerminalNode HOUR() { return getToken(WorkflowParser.HOUR, 0); }
		public TerminalNode DAY() { return getToken(WorkflowParser.DAY, 0); }
		public DelayContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_delay; }
	}

	public final DelayContext delay() throws RecognitionException {
		DelayContext _localctx = new DelayContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_delay);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			number();
			setState(165);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << DAY) | (1L << HOUR) | (1L << MINUTE))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Switch_stateContext extends ParserRuleContext {
		public TerminalNode SWITCH() { return getToken(WorkflowParser.SWITCH, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode WHEN() { return getToken(WorkflowParser.WHEN, 0); }
		public Rule_conditionContext rule_condition() {
			return getRuleContext(Rule_conditionContext.class,0);
		}
		public List<Execute2Context> execute2() {
			return getRuleContexts(Execute2Context.class);
		}
		public Execute2Context execute2(int i) {
			return getRuleContext(Execute2Context.class,i);
		}
		public TerminalNode WAITING() { return getToken(WorkflowParser.WAITING, 0); }
		public DelayContext delay() {
			return getRuleContext(DelayContext.class,0);
		}
		public TerminalNode BEFORE() { return getToken(WorkflowParser.BEFORE, 0); }
		public Switch_stateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_switch_state; }
	}

	public final Switch_stateContext switch_state() throws RecognitionException {
		Switch_stateContext _localctx = new Switch_stateContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_switch_state);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(169);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==WHEN) {
				{
				setState(167);
				match(WHEN);
				setState(168);
				rule_condition(0);
				}
			}

			setState(190);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,18,_ctx) ) {
			case 1:
				{
				setState(174);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==EXECUTE || _la==ON) {
					{
					{
					setState(171);
					execute2();
					}
					}
					setState(176);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				setState(181);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==WAITING) {
					{
					setState(177);
					match(WAITING);
					setState(178);
					delay();
					setState(179);
					match(BEFORE);
					}
				}

				setState(183);
				match(SWITCH);
				setState(184);
				key();
				}
				break;
			case 2:
				{
				setState(186); 
				_errHandler.sync(this);
				_alt = 1;
				do {
					switch (_alt) {
					case 1:
						{
						{
						setState(185);
						execute2();
						}
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					setState(188); 
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,17,_ctx);
				} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExecuteContext extends ParserRuleContext {
		public TerminalNode ON() { return getToken(WorkflowParser.ON, 0); }
		public TerminalNode EXECUTE() { return getToken(WorkflowParser.EXECUTE, 0); }
		public TerminalNode LEFT_PAREN() { return getToken(WorkflowParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(WorkflowParser.RIGHT_PAREN, 0); }
		public TerminalNode ENTER() { return getToken(WorkflowParser.ENTER, 0); }
		public TerminalNode EXIT() { return getToken(WorkflowParser.EXIT, 0); }
		public ActionsContext actions() {
			return getRuleContext(ActionsContext.class,0);
		}
		public ExecuteContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_execute; }
	}

	public final ExecuteContext execute() throws RecognitionException {
		ExecuteContext _localctx = new ExecuteContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_execute);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(192);
			match(ON);
			setState(197);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				{
				setState(193);
				match(ENTER);
				}
				break;
			case 2:
				{
				setState(194);
				match(EXIT);
				}
				break;
			case 3:
				{
				setState(195);
				match(ENTER);
				setState(196);
				match(EXIT);
				}
				break;
			}
			setState(199);
			match(EXECUTE);
			setState(200);
			match(LEFT_PAREN);
			setState(202);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CHAR_STRING || _la==REGULAR_ID) {
				{
				setState(201);
				actions();
				}
			}

			setState(204);
			match(RIGHT_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Execute2Context extends ParserRuleContext {
		public TerminalNode EXECUTE() { return getToken(WorkflowParser.EXECUTE, 0); }
		public TerminalNode LEFT_PAREN() { return getToken(WorkflowParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(WorkflowParser.RIGHT_PAREN, 0); }
		public TerminalNode ON() { return getToken(WorkflowParser.ON, 0); }
		public TerminalNode EXIT() { return getToken(WorkflowParser.EXIT, 0); }
		public ActionsContext actions() {
			return getRuleContext(ActionsContext.class,0);
		}
		public Execute2Context(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_execute2; }
	}

	public final Execute2Context execute2() throws RecognitionException {
		Execute2Context _localctx = new Execute2Context(_ctx, getState());
		enterRule(_localctx, 26, RULE_execute2);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(208);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ON) {
				{
				setState(206);
				match(ON);
				setState(207);
				match(EXIT);
				}
			}

			setState(210);
			match(EXECUTE);
			setState(211);
			match(LEFT_PAREN);
			setState(213);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CHAR_STRING || _la==REGULAR_ID) {
				{
				setState(212);
				actions();
				}
			}

			setState(215);
			match(RIGHT_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ActionsContext extends ParserRuleContext {
		public List<ActionContext> action() {
			return getRuleContexts(ActionContext.class);
		}
		public ActionContext action(int i) {
			return getRuleContext(ActionContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(WorkflowParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(WorkflowParser.COMMA, i);
		}
		public ActionsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_actions; }
	}

	public final ActionsContext actions() throws RecognitionException {
		ActionsContext _localctx = new ActionsContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_actions);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(217);
			action();
			setState(222);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(218);
				match(COMMA);
				setState(219);
				action();
				}
				}
				setState(224);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ActionContext extends ParserRuleContext {
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode LEFT_PAREN() { return getToken(WorkflowParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(WorkflowParser.RIGHT_PAREN, 0); }
		public ArgumentsContext arguments() {
			return getRuleContext(ArgumentsContext.class,0);
		}
		public ActionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_action; }
	}

	public final ActionContext action() throws RecognitionException {
		ActionContext _localctx = new ActionContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_action);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(225);
			key();
			setState(226);
			match(LEFT_PAREN);
			setState(228);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==CHAR_STRING) {
				{
				setState(227);
				arguments();
				}
			}

			setState(230);
			match(RIGHT_PAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ArgumentsContext extends ParserRuleContext {
		public List<StringContext> string() {
			return getRuleContexts(StringContext.class);
		}
		public StringContext string(int i) {
			return getRuleContext(StringContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(WorkflowParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(WorkflowParser.COMMA, i);
		}
		public ArgumentsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arguments; }
	}

	public final ArgumentsContext arguments() throws RecognitionException {
		ArgumentsContext _localctx = new ArgumentsContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_arguments);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(232);
			string();
			setState(237);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(233);
				match(COMMA);
				setState(234);
				string();
				}
				}
				setState(239);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Rule_conditionContext extends ParserRuleContext {
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public TerminalNode NOT() { return getToken(WorkflowParser.NOT, 0); }
		public List<Rule_conditionContext> rule_condition() {
			return getRuleContexts(Rule_conditionContext.class);
		}
		public Rule_conditionContext rule_condition(int i) {
			return getRuleContext(Rule_conditionContext.class,i);
		}
		public TerminalNode LEFT_PAREN() { return getToken(WorkflowParser.LEFT_PAREN, 0); }
		public TerminalNode RIGHT_PAREN() { return getToken(WorkflowParser.RIGHT_PAREN, 0); }
		public TerminalNode AND() { return getToken(WorkflowParser.AND, 0); }
		public TerminalNode OR() { return getToken(WorkflowParser.OR, 0); }
		public Rule_conditionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rule_condition; }
	}

	public final Rule_conditionContext rule_condition() throws RecognitionException {
		return rule_condition(0);
	}

	private Rule_conditionContext rule_condition(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		Rule_conditionContext _localctx = new Rule_conditionContext(_ctx, _parentState);
		Rule_conditionContext _prevctx = _localctx;
		int _startState = 34;
		enterRecursionRule(_localctx, 34, RULE_rule_condition, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(248);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CHAR_STRING:
			case REGULAR_ID:
				{
				setState(241);
				key();
				}
				break;
			case NOT:
				{
				setState(242);
				match(NOT);
				setState(243);
				rule_condition(4);
				}
				break;
			case LEFT_PAREN:
				{
				setState(244);
				match(LEFT_PAREN);
				setState(245);
				rule_condition(0);
				setState(246);
				match(RIGHT_PAREN);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(258);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					setState(256);
					_errHandler.sync(this);
					switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
					case 1:
						{
						_localctx = new Rule_conditionContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_rule_condition);
						setState(250);
						if (!(precpred(_ctx, 3))) throw new FailedPredicateException(this, "precpred(_ctx, 3)");
						setState(251);
						match(AND);
						setState(252);
						rule_condition(4);
						}
						break;
					case 2:
						{
						_localctx = new Rule_conditionContext(_parentctx, _parentState);
						pushNewRecursionContext(_localctx, _startState, RULE_rule_condition);
						setState(253);
						if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
						setState(254);
						match(OR);
						setState(255);
						rule_condition(3);
						}
						break;
					}
					} 
				}
				setState(260);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,28,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Action_statementContext extends ParserRuleContext {
		public TerminalNode ACTION() { return getToken(WorkflowParser.ACTION, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public Action_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_action_statement; }
	}

	public final Action_statementContext action_statement() throws RecognitionException {
		Action_statementContext _localctx = new Action_statementContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_action_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(261);
			match(ACTION);
			setState(262);
			key();
			setState(263);
			comment();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Rule_statementContext extends ParserRuleContext {
		public TerminalNode RULE() { return getToken(WorkflowParser.RULE, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public Rule_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rule_statement; }
	}

	public final Rule_statementContext rule_statement() throws RecognitionException {
		Rule_statementContext _localctx = new Rule_statementContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_rule_statement);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(265);
			match(RULE);
			setState(266);
			key();
			setState(267);
			comment();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Event_statementContext extends ParserRuleContext {
		public TerminalNode EVENT() { return getToken(WorkflowParser.EVENT, 0); }
		public KeyContext key() {
			return getRuleContext(KeyContext.class,0);
		}
		public CommentContext comment() {
			return getRuleContext(CommentContext.class,0);
		}
		public TerminalNode NO() { return getToken(WorkflowParser.NO, 0); }
		public Event_statementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_event_statement; }
	}

	public final Event_statementContext event_statement() throws RecognitionException {
		Event_statementContext _localctx = new Event_statementContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_event_statement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(270);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NO) {
				{
				setState(269);
				match(NO);
				}
			}

			setState(272);
			match(EVENT);
			setState(273);
			key();
			setState(274);
			comment();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumberContext extends ParserRuleContext {
		public TerminalNode NUMBER() { return getToken(WorkflowParser.NUMBER, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_number; }
	}

	public final NumberContext number() throws RecognitionException {
		NumberContext _localctx = new NumberContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_number);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(276);
			match(NUMBER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class KeyContext extends ParserRuleContext {
		public TerminalNode CHAR_STRING() { return getToken(WorkflowParser.CHAR_STRING, 0); }
		public TerminalNode REGULAR_ID() { return getToken(WorkflowParser.REGULAR_ID, 0); }
		public KeyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_key; }
	}

	public final KeyContext key() throws RecognitionException {
		KeyContext _localctx = new KeyContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_key);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(278);
			_la = _input.LA(1);
			if ( !(_la==CHAR_STRING || _la==REGULAR_ID) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CommentContext extends ParserRuleContext {
		public TerminalNode CHAR_COMMENT() { return getToken(WorkflowParser.CHAR_COMMENT, 0); }
		public CommentContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_comment; }
	}

	public final CommentContext comment() throws RecognitionException {
		CommentContext _localctx = new CommentContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_comment);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(280);
			match(CHAR_COMMENT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumericContext extends ParserRuleContext {
		public List<NumbersContext> numbers() {
			return getRuleContexts(NumbersContext.class);
		}
		public NumbersContext numbers(int i) {
			return getRuleContext(NumbersContext.class,i);
		}
		public TerminalNode DOT() { return getToken(WorkflowParser.DOT, 0); }
		public NumericContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numeric; }
	}

	public final NumericContext numeric() throws RecognitionException {
		NumericContext _localctx = new NumericContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_numeric);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(282);
			numbers();
			{
			setState(283);
			match(DOT);
			setState(284);
			numbers();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumbersContext extends ParserRuleContext {
		public List<TerminalNode> NUMBER() { return getTokens(WorkflowParser.NUMBER); }
		public TerminalNode NUMBER(int i) {
			return getToken(WorkflowParser.NUMBER, i);
		}
		public NumbersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numbers; }
	}

	public final NumbersContext numbers() throws RecognitionException {
		NumbersContext _localctx = new NumbersContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_numbers);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(289);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==NUMBER) {
				{
				{
				setState(286);
				match(NUMBER);
				}
				}
				setState(291);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringContext extends ParserRuleContext {
		public TerminalNode CHAR_STRING() { return getToken(WorkflowParser.CHAR_STRING, 0); }
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_string);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(292);
			match(CHAR_STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 17:
			return rule_condition_sempred((Rule_conditionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean rule_condition_sempred(Rule_conditionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 3);
		case 1:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3/\u0129\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\3\2\3\2\3\2\3\2\5\2=\n\2\3\2\3\2\7\2A\n"+
		"\2\f\2\16\2D\13\2\3\2\3\2\6\2H\n\2\r\2\16\2I\5\2L\n\2\3\2\3\2\3\2\7\2"+
		"Q\n\2\f\2\16\2T\13\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\3\7\3`\n\3"+
		"\f\3\16\3c\13\3\3\4\3\4\3\4\3\4\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\5\6q\n"+
		"\6\3\7\3\7\3\7\3\7\3\7\3\b\3\b\3\b\3\b\5\b|\n\b\3\t\3\t\3\t\3\t\6\t\u0082"+
		"\n\t\r\t\16\t\u0083\3\n\3\n\5\n\u0088\n\n\3\n\3\n\3\n\3\n\7\n\u008e\n"+
		"\n\f\n\16\n\u0091\13\n\3\n\7\n\u0094\n\n\f\n\16\n\u0097\13\n\3\13\3\13"+
		"\3\13\3\13\3\13\3\13\3\13\5\13\u00a0\n\13\3\13\6\13\u00a3\n\13\r\13\16"+
		"\13\u00a4\3\f\3\f\3\f\3\r\3\r\5\r\u00ac\n\r\3\r\7\r\u00af\n\r\f\r\16\r"+
		"\u00b2\13\r\3\r\3\r\3\r\3\r\5\r\u00b8\n\r\3\r\3\r\3\r\6\r\u00bd\n\r\r"+
		"\r\16\r\u00be\5\r\u00c1\n\r\3\16\3\16\3\16\3\16\3\16\5\16\u00c8\n\16\3"+
		"\16\3\16\3\16\5\16\u00cd\n\16\3\16\3\16\3\17\3\17\5\17\u00d3\n\17\3\17"+
		"\3\17\3\17\5\17\u00d8\n\17\3\17\3\17\3\20\3\20\3\20\7\20\u00df\n\20\f"+
		"\20\16\20\u00e2\13\20\3\21\3\21\3\21\5\21\u00e7\n\21\3\21\3\21\3\22\3"+
		"\22\3\22\7\22\u00ee\n\22\f\22\16\22\u00f1\13\22\3\23\3\23\3\23\3\23\3"+
		"\23\3\23\3\23\3\23\5\23\u00fb\n\23\3\23\3\23\3\23\3\23\3\23\3\23\7\23"+
		"\u0103\n\23\f\23\16\23\u0106\13\23\3\24\3\24\3\24\3\24\3\25\3\25\3\25"+
		"\3\25\3\26\5\26\u0111\n\26\3\26\3\26\3\26\3\26\3\27\3\27\3\30\3\30\3\31"+
		"\3\31\3\32\3\32\3\32\3\32\3\33\7\33\u0122\n\33\f\33\16\33\u0125\13\33"+
		"\3\34\3\34\3\34\2\3$\35\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*"+
		",.\60\62\64\66\2\5\4\2\20\20\23\23\5\2\t\t\21\21\25\25\4\2$$//\2\u0134"+
		"\28\3\2\2\2\4W\3\2\2\2\6d\3\2\2\2\bh\3\2\2\2\nj\3\2\2\2\fr\3\2\2\2\16"+
		"{\3\2\2\2\20}\3\2\2\2\22\u0085\3\2\2\2\24\u009f\3\2\2\2\26\u00a6\3\2\2"+
		"\2\30\u00ab\3\2\2\2\32\u00c2\3\2\2\2\34\u00d2\3\2\2\2\36\u00db\3\2\2\2"+
		" \u00e3\3\2\2\2\"\u00ea\3\2\2\2$\u00fa\3\2\2\2&\u0107\3\2\2\2(\u010b\3"+
		"\2\2\2*\u0110\3\2\2\2,\u0116\3\2\2\2.\u0118\3\2\2\2\60\u011a\3\2\2\2\62"+
		"\u011c\3\2\2\2\64\u0123\3\2\2\2\66\u0126\3\2\2\289\7\26\2\29<\5.\30\2"+
		":;\7\b\2\2;=\5\60\31\2<:\3\2\2\2<=\3\2\2\2=B\3\2\2\2>?\7\22\2\2?A\7$\2"+
		"\2@>\3\2\2\2AD\3\2\2\2B@\3\2\2\2BC\3\2\2\2CK\3\2\2\2DB\3\2\2\2EG\7\24"+
		"\2\2FH\5\4\3\2GF\3\2\2\2HI\3\2\2\2IG\3\2\2\2IJ\3\2\2\2JL\3\2\2\2KE\3\2"+
		"\2\2KL\3\2\2\2LR\3\2\2\2MN\5\b\5\2NO\7(\2\2OQ\3\2\2\2PM\3\2\2\2QT\3\2"+
		"\2\2RP\3\2\2\2RS\3\2\2\2SU\3\2\2\2TR\3\2\2\2UV\7\2\2\3V\3\3\2\2\2WX\7"+
		"&\2\2XY\5\6\4\2Ya\7\'\2\2Z[\7)\2\2[\\\7&\2\2\\]\5\6\4\2]^\7\'\2\2^`\3"+
		"\2\2\2_Z\3\2\2\2`c\3\2\2\2a_\3\2\2\2ab\3\2\2\2b\5\3\2\2\2ca\3\2\2\2de"+
		"\5.\30\2ef\7\16\2\2fg\7$\2\2g\7\3\2\2\2hi\5\n\6\2i\t\3\2\2\2jp\7\n\2\2"+
		"kq\5*\26\2lq\5(\25\2mq\5&\24\2nq\5\f\7\2oq\5\20\t\2pk\3\2\2\2pl\3\2\2"+
		"\2pm\3\2\2\2pn\3\2\2\2po\3\2\2\2q\13\3\2\2\2rs\7\7\2\2st\5.\30\2tu\5\16"+
		"\b\2uv\5\60\31\2v\r\3\2\2\2w|\5\66\34\2x|\5\64\33\2y|\5\26\f\2z|\7/\2"+
		"\2{w\3\2\2\2{x\3\2\2\2{y\3\2\2\2{z\3\2\2\2|\17\3\2\2\2}~\7\36\2\2~\177"+
		"\5.\30\2\177\u0081\5\60\31\2\u0080\u0082\5\22\n\2\u0081\u0080\3\2\2\2"+
		"\u0082\u0083\3\2\2\2\u0083\u0081\3\2\2\2\u0083\u0084\3\2\2\2\u0084\21"+
		"\3\2\2\2\u0085\u0087\7\"\2\2\u0086\u0088\t\2\2\2\u0087\u0086\3\2\2\2\u0087"+
		"\u0088\3\2\2\2\u0088\u0089\3\2\2\2\u0089\u008a\7\37\2\2\u008a\u008b\5"+
		".\30\2\u008b\u008f\5\60\31\2\u008c\u008e\5\32\16\2\u008d\u008c\3\2\2\2"+
		"\u008e\u0091\3\2\2\2\u008f\u008d\3\2\2\2\u008f\u0090\3\2\2\2\u0090\u0095"+
		"\3\2\2\2\u0091\u008f\3\2\2\2\u0092\u0094\5\24\13\2\u0093\u0092\3\2\2\2"+
		"\u0094\u0097\3\2\2\2\u0095\u0093\3\2\2\2\u0095\u0096\3\2\2\2\u0096\23"+
		"\3\2\2\2\u0097\u0095\3\2\2\2\u0098\u0099\7\27\2\2\u0099\u00a0\7\13\2\2"+
		"\u009a\u009b\7\31\2\2\u009b\u009c\7\13\2\2\u009c\u00a0\5.\30\2\u009d\u009e"+
		"\7\4\2\2\u009e\u00a0\5\26\f\2\u009f\u0098\3\2\2\2\u009f\u009a\3\2\2\2"+
		"\u009f\u009d\3\2\2\2\u00a0\u00a2\3\2\2\2\u00a1\u00a3\5\30\r\2\u00a2\u00a1"+
		"\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\u00a2\3\2\2\2\u00a4\u00a5\3\2\2\2\u00a5"+
		"\25\3\2\2\2\u00a6\u00a7\5,\27\2\u00a7\u00a8\t\3\2\2\u00a8\27\3\2\2\2\u00a9"+
		"\u00aa\7#\2\2\u00aa\u00ac\5$\23\2\u00ab\u00a9\3\2\2\2\u00ab\u00ac\3\2"+
		"\2\2\u00ac\u00c0\3\2\2\2\u00ad\u00af\5\34\17\2\u00ae\u00ad\3\2\2\2\u00af"+
		"\u00b2\3\2\2\2\u00b0\u00ae\3\2\2\2\u00b0\u00b1\3\2\2\2\u00b1\u00b7\3\2"+
		"\2\2\u00b2\u00b0\3\2\2\2\u00b3\u00b4\7!\2\2\u00b4\u00b5\5\26\f\2\u00b5"+
		"\u00b6\7\6\2\2\u00b6\u00b8\3\2\2\2\u00b7\u00b3\3\2\2\2\u00b7\u00b8\3\2"+
		"\2\2\u00b8\u00b9\3\2\2\2\u00b9\u00ba\7\35\2\2\u00ba\u00c1\5.\30\2\u00bb"+
		"\u00bd\5\34\17\2\u00bc\u00bb\3\2\2\2\u00bd\u00be\3\2\2\2\u00be\u00bc\3"+
		"\2\2\2\u00be\u00bf\3\2\2\2\u00bf\u00c1\3\2\2\2\u00c0\u00b0\3\2\2\2\u00c0"+
		"\u00bc\3\2\2\2\u00c1\31\3\2\2\2\u00c2\u00c7\7\31\2\2\u00c3\u00c8\7\r\2"+
		"\2\u00c4\u00c8\7\17\2\2\u00c5\u00c6\7\r\2\2\u00c6\u00c8\7\17\2\2\u00c7"+
		"\u00c3\3\2\2\2\u00c7\u00c4\3\2\2\2\u00c7\u00c5\3\2\2\2\u00c8\u00c9\3\2"+
		"\2\2\u00c9\u00ca\7\f\2\2\u00ca\u00cc\7&\2\2\u00cb\u00cd\5\36\20\2\u00cc"+
		"\u00cb\3\2\2\2\u00cc\u00cd\3\2\2\2\u00cd\u00ce\3\2\2\2\u00ce\u00cf\7\'"+
		"\2\2\u00cf\33\3\2\2\2\u00d0\u00d1\7\31\2\2\u00d1\u00d3\7\17\2\2\u00d2"+
		"\u00d0\3\2\2\2\u00d2\u00d3\3\2\2\2\u00d3\u00d4\3\2\2\2\u00d4\u00d5\7\f"+
		"\2\2\u00d5\u00d7\7&\2\2\u00d6\u00d8\5\36\20\2\u00d7\u00d6\3\2\2\2\u00d7"+
		"\u00d8\3\2\2\2\u00d8\u00d9\3\2\2\2\u00d9\u00da\7\'\2\2\u00da\35\3\2\2"+
		"\2\u00db\u00e0\5 \21\2\u00dc\u00dd\7)\2\2\u00dd\u00df\5 \21\2\u00de\u00dc"+
		"\3\2\2\2\u00df\u00e2\3\2\2\2\u00e0\u00de\3\2\2\2\u00e0\u00e1\3\2\2\2\u00e1"+
		"\37\3\2\2\2\u00e2\u00e0\3\2\2\2\u00e3\u00e4\5.\30\2\u00e4\u00e6\7&\2\2"+
		"\u00e5\u00e7\5\"\22\2\u00e6\u00e5\3\2\2\2\u00e6\u00e7\3\2\2\2\u00e7\u00e8"+
		"\3\2\2\2\u00e8\u00e9\7\'\2\2\u00e9!\3\2\2\2\u00ea\u00ef\5\66\34\2\u00eb"+
		"\u00ec\7)\2\2\u00ec\u00ee\5\66\34\2\u00ed\u00eb\3\2\2\2\u00ee\u00f1\3"+
		"\2\2\2\u00ef\u00ed\3\2\2\2\u00ef\u00f0\3\2\2\2\u00f0#\3\2\2\2\u00f1\u00ef"+
		"\3\2\2\2\u00f2\u00f3\b\23\1\2\u00f3\u00fb\5.\30\2\u00f4\u00f5\7\30\2\2"+
		"\u00f5\u00fb\5$\23\6\u00f6\u00f7\7&\2\2\u00f7\u00f8\5$\23\2\u00f8\u00f9"+
		"\7\'\2\2\u00f9\u00fb\3\2\2\2\u00fa\u00f2\3\2\2\2\u00fa\u00f4\3\2\2\2\u00fa"+
		"\u00f6\3\2\2\2\u00fb\u0104\3\2\2\2\u00fc\u00fd\f\5\2\2\u00fd\u00fe\7\5"+
		"\2\2\u00fe\u0103\5$\23\6\u00ff\u0100\f\4\2\2\u0100\u0101\7\32\2\2\u0101"+
		"\u0103\5$\23\5\u0102\u00fc\3\2\2\2\u0102\u00ff\3\2\2\2\u0103\u0106\3\2"+
		"\2\2\u0104\u0102\3\2\2\2\u0104\u0105\3\2\2\2\u0105%\3\2\2\2\u0106\u0104"+
		"\3\2\2\2\u0107\u0108\7\3\2\2\u0108\u0109\5.\30\2\u0109\u010a\5\60\31\2"+
		"\u010a\'\3\2\2\2\u010b\u010c\7\34\2\2\u010c\u010d\5.\30\2\u010d\u010e"+
		"\5\60\31\2\u010e)\3\2\2\2\u010f\u0111\7\27\2\2\u0110\u010f\3\2\2\2\u0110"+
		"\u0111\3\2\2\2\u0111\u0112\3\2\2\2\u0112\u0113\7\13\2\2\u0113\u0114\5"+
		".\30\2\u0114\u0115\5\60\31\2\u0115+\3\2\2\2\u0116\u0117\7,\2\2\u0117-"+
		"\3\2\2\2\u0118\u0119\t\4\2\2\u0119/\3\2\2\2\u011a\u011b\7%\2\2\u011b\61"+
		"\3\2\2\2\u011c\u011d\5\64\33\2\u011d\u011e\7*\2\2\u011e\u011f\5\64\33"+
		"\2\u011f\63\3\2\2\2\u0120\u0122\7,\2\2\u0121\u0120\3\2\2\2\u0122\u0125"+
		"\3\2\2\2\u0123\u0121\3\2\2\2\u0123\u0124\3\2\2\2\u0124\65\3\2\2\2\u0125"+
		"\u0123\3\2\2\2\u0126\u0127\7$\2\2\u0127\67\3\2\2\2!<BIKRap{\u0083\u0087"+
		"\u008f\u0095\u009f\u00a4\u00ab\u00b0\u00b7\u00be\u00c0\u00c7\u00cc\u00d2"+
		"\u00d7\u00e0\u00e6\u00ef\u00fa\u0102\u0104\u0110\u0123";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}