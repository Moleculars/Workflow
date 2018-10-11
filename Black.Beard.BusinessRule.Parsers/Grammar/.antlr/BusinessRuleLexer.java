// Generated from c:\Users\g.beard\Desktop\anomalies\Pssa.BusinessRule.Parsers\Grammar/BusinessRuleLexer.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class BusinessRuleLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		CONST=1, DATA=2, DAY=3, DECLARE=4, DESCRIPTION=5, ELSE=6, EVENT=7, FUNCTION=8, 
		HOUR=9, LOAD=10, MATCHING=11, MINUTE=12, NAME=13, RETURN=14, WHEN=15, 
		CHAR_STRING=16, CHAR_COMMENT=17, LEFT_PAREN=18, LEFT_BRACKET=19, RIGHT_PAREN=20, 
		RIGHT_BRACKET=21, SEMICOLON=22, COMMA=23, PLUS=24, MINUS=25, TIME=26, 
		DOT=27, DIVID=28, NOT=29, EQUAL=30, MODULO=31, POWER=32, NOT_EQUAL=33, 
		GREATER=34, GREATER_OR_EQUAL=35, LESS=36, LESS_OR_EQUAL=37, XOR=38, OR=39, 
		AND=40, ANDALSO=41, SPACES=42, NUMBER=43, SINGLE_LINE_COMMENT=44, MULTI_LINE_COMMENT=45, 
		REGULAR_ID=46;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"CONST", "DATA", "DAY", "DECLARE", "DESCRIPTION", "ELSE", "EVENT", "FUNCTION", 
		"HOUR", "LOAD", "MATCHING", "MINUTE", "NAME", "RETURN", "WHEN", "CHAR_STRING", 
		"CHAR_COMMENT", "LEFT_PAREN", "LEFT_BRACKET", "RIGHT_PAREN", "RIGHT_BRACKET", 
		"SEMICOLON", "COMMA", "PLUS", "MINUS", "TIME", "DOT", "DIVID", "NOT", 
		"EQUAL", "MODULO", "POWER", "NOT_EQUAL", "GREATER", "GREATER_OR_EQUAL", 
		"LESS", "LESS_OR_EQUAL", "XOR", "OR", "AND", "ANDALSO", "SPACES", "SIMPLE_LETTER", 
		"NUMBER", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", "NEWLINE", "SPACE", 
		"REGULAR_ID"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'CONST'", "'DATA'", "'DAY'", "'DECLARE'", "'DESCRIPTION'", "'ELSE'", 
		"'EVENT'", "'FUNCTION'", "'HOUR'", "'LOAD'", "'MATCHING'", "'MINUTE'", 
		"'NAME'", "'RETURN'", "'WHEN'", null, null, "'('", "'['", "')'", "']'", 
		"';'", "','", "'+'", "'-'", "'*'", "'.'", "'\\'", "'!'", "'='", "'%'", 
		"'^'", "'!='", "'>'", "'>='", "'<'", "'<='", "'||'", "'|'", "'&'", "'&&'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "CONST", "DATA", "DAY", "DECLARE", "DESCRIPTION", "ELSE", "EVENT", 
		"FUNCTION", "HOUR", "LOAD", "MATCHING", "MINUTE", "NAME", "RETURN", "WHEN", 
		"CHAR_STRING", "CHAR_COMMENT", "LEFT_PAREN", "LEFT_BRACKET", "RIGHT_PAREN", 
		"RIGHT_BRACKET", "SEMICOLON", "COMMA", "PLUS", "MINUS", "TIME", "DOT", 
		"DIVID", "NOT", "EQUAL", "MODULO", "POWER", "NOT_EQUAL", "GREATER", "GREATER_OR_EQUAL", 
		"LESS", "LESS_OR_EQUAL", "XOR", "OR", "AND", "ANDALSO", "SPACES", "NUMBER", 
		"SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", "REGULAR_ID"
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


	public BusinessRuleLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "BusinessRuleLexer.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\60\u014d\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t"+
		" \4!\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t"+
		"+\4,\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\3\2\3\2\3\2\3"+
		"\2\3\2\3\2\3\3\3\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3"+
		"\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3\n"+
		"\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3\f\3\f\3\f"+
		"\3\f\3\f\3\r\3\r\3\r\3\r\3\r\3\r\3\r\3\16\3\16\3\16\3\16\3\16\3\17\3\17"+
		"\3\17\3\17\3\17\3\17\3\17\3\20\3\20\3\20\3\20\3\20\3\21\3\21\3\21\3\21"+
		"\3\21\6\21\u00cd\n\21\r\21\16\21\u00ce\3\21\3\21\3\22\3\22\3\22\3\22\3"+
		"\22\7\22\u00d8\n\22\f\22\16\22\u00db\13\22\3\22\3\22\3\23\3\23\3\24\3"+
		"\24\3\25\3\25\3\26\3\26\3\27\3\27\3\30\3\30\3\31\3\31\3\32\3\32\3\33\3"+
		"\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \3!\3!\3\"\3\"\3\"\3"+
		"#\3#\3$\3$\3$\3%\3%\3&\3&\3&\3\'\3\'\3\'\3(\3(\3)\3)\3*\3*\3*\3+\6+\u0115"+
		"\n+\r+\16+\u0116\3+\3+\3,\3,\3-\6-\u011e\n-\r-\16-\u011f\3.\3.\3.\3.\7"+
		".\u0126\n.\f.\16.\u0129\13.\3.\3.\5.\u012d\n.\3.\3.\3/\3/\3/\3/\7/\u0135"+
		"\n/\f/\16/\u0138\13/\3/\3/\3/\3/\3/\3\60\5\60\u0140\n\60\3\60\3\60\3\61"+
		"\3\61\3\62\3\62\3\62\7\62\u0149\n\62\f\62\16\62\u014c\13\62\3\u0136\2"+
		"\63\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35"+
		"\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36"+
		";\37= ?!A\"C#E$G%I&K\'M(O)Q*S+U,W\2Y-[.]/_\2a\2c\60\3\2\n\5\2\f\f\17\17"+
		"))\5\2\f\f\17\17$$\5\2\13\f\17\17\"\"\4\2C\\c|\3\2\62;\4\2\f\f\17\17\4"+
		"\2\13\13\"\"\5\2%&\62;aa\2\u0157\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2\2\2"+
		"\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23\3\2"+
		"\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2\2\2"+
		"\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2"+
		"\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2"+
		"\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2\2\2"+
		"\2C\3\2\2\2\2E\3\2\2\2\2G\3\2\2\2\2I\3\2\2\2\2K\3\2\2\2\2M\3\2\2\2\2O"+
		"\3\2\2\2\2Q\3\2\2\2\2S\3\2\2\2\2U\3\2\2\2\2Y\3\2\2\2\2[\3\2\2\2\2]\3\2"+
		"\2\2\2c\3\2\2\2\3e\3\2\2\2\5k\3\2\2\2\7p\3\2\2\2\tt\3\2\2\2\13|\3\2\2"+
		"\2\r\u0088\3\2\2\2\17\u008d\3\2\2\2\21\u0093\3\2\2\2\23\u009c\3\2\2\2"+
		"\25\u00a1\3\2\2\2\27\u00a6\3\2\2\2\31\u00af\3\2\2\2\33\u00b6\3\2\2\2\35"+
		"\u00bb\3\2\2\2\37\u00c2\3\2\2\2!\u00c7\3\2\2\2#\u00d2\3\2\2\2%\u00de\3"+
		"\2\2\2\'\u00e0\3\2\2\2)\u00e2\3\2\2\2+\u00e4\3\2\2\2-\u00e6\3\2\2\2/\u00e8"+
		"\3\2\2\2\61\u00ea\3\2\2\2\63\u00ec\3\2\2\2\65\u00ee\3\2\2\2\67\u00f0\3"+
		"\2\2\29\u00f2\3\2\2\2;\u00f4\3\2\2\2=\u00f6\3\2\2\2?\u00f8\3\2\2\2A\u00fa"+
		"\3\2\2\2C\u00fc\3\2\2\2E\u00ff\3\2\2\2G\u0101\3\2\2\2I\u0104\3\2\2\2K"+
		"\u0106\3\2\2\2M\u0109\3\2\2\2O\u010c\3\2\2\2Q\u010e\3\2\2\2S\u0110\3\2"+
		"\2\2U\u0114\3\2\2\2W\u011a\3\2\2\2Y\u011d\3\2\2\2[\u0121\3\2\2\2]\u0130"+
		"\3\2\2\2_\u013f\3\2\2\2a\u0143\3\2\2\2c\u0145\3\2\2\2ef\7E\2\2fg\7Q\2"+
		"\2gh\7P\2\2hi\7U\2\2ij\7V\2\2j\4\3\2\2\2kl\7F\2\2lm\7C\2\2mn\7V\2\2no"+
		"\7C\2\2o\6\3\2\2\2pq\7F\2\2qr\7C\2\2rs\7[\2\2s\b\3\2\2\2tu\7F\2\2uv\7"+
		"G\2\2vw\7E\2\2wx\7N\2\2xy\7C\2\2yz\7T\2\2z{\7G\2\2{\n\3\2\2\2|}\7F\2\2"+
		"}~\7G\2\2~\177\7U\2\2\177\u0080\7E\2\2\u0080\u0081\7T\2\2\u0081\u0082"+
		"\7K\2\2\u0082\u0083\7R\2\2\u0083\u0084\7V\2\2\u0084\u0085\7K\2\2\u0085"+
		"\u0086\7Q\2\2\u0086\u0087\7P\2\2\u0087\f\3\2\2\2\u0088\u0089\7G\2\2\u0089"+
		"\u008a\7N\2\2\u008a\u008b\7U\2\2\u008b\u008c\7G\2\2\u008c\16\3\2\2\2\u008d"+
		"\u008e\7G\2\2\u008e\u008f\7X\2\2\u008f\u0090\7G\2\2\u0090\u0091\7P\2\2"+
		"\u0091\u0092\7V\2\2\u0092\20\3\2\2\2\u0093\u0094\7H\2\2\u0094\u0095\7"+
		"W\2\2\u0095\u0096\7P\2\2\u0096\u0097\7E\2\2\u0097\u0098\7V\2\2\u0098\u0099"+
		"\7K\2\2\u0099\u009a\7Q\2\2\u009a\u009b\7P\2\2\u009b\22\3\2\2\2\u009c\u009d"+
		"\7J\2\2\u009d\u009e\7Q\2\2\u009e\u009f\7W\2\2\u009f\u00a0\7T\2\2\u00a0"+
		"\24\3\2\2\2\u00a1\u00a2\7N\2\2\u00a2\u00a3\7Q\2\2\u00a3\u00a4\7C\2\2\u00a4"+
		"\u00a5\7F\2\2\u00a5\26\3\2\2\2\u00a6\u00a7\7O\2\2\u00a7\u00a8\7C\2\2\u00a8"+
		"\u00a9\7V\2\2\u00a9\u00aa\7E\2\2\u00aa\u00ab\7J\2\2\u00ab\u00ac\7K\2\2"+
		"\u00ac\u00ad\7P\2\2\u00ad\u00ae\7I\2\2\u00ae\30\3\2\2\2\u00af\u00b0\7"+
		"O\2\2\u00b0\u00b1\7K\2\2\u00b1\u00b2\7P\2\2\u00b2\u00b3\7W\2\2\u00b3\u00b4"+
		"\7V\2\2\u00b4\u00b5\7G\2\2\u00b5\32\3\2\2\2\u00b6\u00b7\7P\2\2\u00b7\u00b8"+
		"\7C\2\2\u00b8\u00b9\7O\2\2\u00b9\u00ba\7G\2\2\u00ba\34\3\2\2\2\u00bb\u00bc"+
		"\7T\2\2\u00bc\u00bd\7G\2\2\u00bd\u00be\7V\2\2\u00be\u00bf\7W\2\2\u00bf"+
		"\u00c0\7T\2\2\u00c0\u00c1\7P\2\2\u00c1\36\3\2\2\2\u00c2\u00c3\7Y\2\2\u00c3"+
		"\u00c4\7J\2\2\u00c4\u00c5\7G\2\2\u00c5\u00c6\7P\2\2\u00c6 \3\2\2\2\u00c7"+
		"\u00cc\7)\2\2\u00c8\u00cd\n\2\2\2\u00c9\u00ca\7)\2\2\u00ca\u00cd\7)\2"+
		"\2\u00cb\u00cd\5_\60\2\u00cc\u00c8\3\2\2\2\u00cc\u00c9\3\2\2\2\u00cc\u00cb"+
		"\3\2\2\2\u00cd\u00ce\3\2\2\2\u00ce\u00cc\3\2\2\2\u00ce\u00cf\3\2\2\2\u00cf"+
		"\u00d0\3\2\2\2\u00d0\u00d1\7)\2\2\u00d1\"\3\2\2\2\u00d2\u00d9\7$\2\2\u00d3"+
		"\u00d8\n\3\2\2\u00d4\u00d5\7$\2\2\u00d5\u00d8\7$\2\2\u00d6\u00d8\5_\60"+
		"\2\u00d7\u00d3\3\2\2\2\u00d7\u00d4\3\2\2\2\u00d7\u00d6\3\2\2\2\u00d8\u00db"+
		"\3\2\2\2\u00d9\u00d7\3\2\2\2\u00d9\u00da\3\2\2\2\u00da\u00dc\3\2\2\2\u00db"+
		"\u00d9\3\2\2\2\u00dc\u00dd\7$\2\2\u00dd$\3\2\2\2\u00de\u00df\7*\2\2\u00df"+
		"&\3\2\2\2\u00e0\u00e1\7]\2\2\u00e1(\3\2\2\2\u00e2\u00e3\7+\2\2\u00e3*"+
		"\3\2\2\2\u00e4\u00e5\7_\2\2\u00e5,\3\2\2\2\u00e6\u00e7\7=\2\2\u00e7.\3"+
		"\2\2\2\u00e8\u00e9\7.\2\2\u00e9\60\3\2\2\2\u00ea\u00eb\7-\2\2\u00eb\62"+
		"\3\2\2\2\u00ec\u00ed\7/\2\2\u00ed\64\3\2\2\2\u00ee\u00ef\7,\2\2\u00ef"+
		"\66\3\2\2\2\u00f0\u00f1\7\60\2\2\u00f18\3\2\2\2\u00f2\u00f3\7^\2\2\u00f3"+
		":\3\2\2\2\u00f4\u00f5\7#\2\2\u00f5<\3\2\2\2\u00f6\u00f7\7?\2\2\u00f7>"+
		"\3\2\2\2\u00f8\u00f9\7\'\2\2\u00f9@\3\2\2\2\u00fa\u00fb\7`\2\2\u00fbB"+
		"\3\2\2\2\u00fc\u00fd\7#\2\2\u00fd\u00fe\7?\2\2\u00feD\3\2\2\2\u00ff\u0100"+
		"\7@\2\2\u0100F\3\2\2\2\u0101\u0102\7@\2\2\u0102\u0103\7?\2\2\u0103H\3"+
		"\2\2\2\u0104\u0105\7>\2\2\u0105J\3\2\2\2\u0106\u0107\7>\2\2\u0107\u0108"+
		"\7?\2\2\u0108L\3\2\2\2\u0109\u010a\7~\2\2\u010a\u010b\7~\2\2\u010bN\3"+
		"\2\2\2\u010c\u010d\7~\2\2\u010dP\3\2\2\2\u010e\u010f\7(\2\2\u010fR\3\2"+
		"\2\2\u0110\u0111\7(\2\2\u0111\u0112\7(\2\2\u0112T\3\2\2\2\u0113\u0115"+
		"\t\4\2\2\u0114\u0113\3\2\2\2\u0115\u0116\3\2\2\2\u0116\u0114\3\2\2\2\u0116"+
		"\u0117\3\2\2\2\u0117\u0118\3\2\2\2\u0118\u0119\b+\2\2\u0119V\3\2\2\2\u011a"+
		"\u011b\t\5\2\2\u011bX\3\2\2\2\u011c\u011e\t\6\2\2\u011d\u011c\3\2\2\2"+
		"\u011e\u011f\3\2\2\2\u011f\u011d\3\2\2\2\u011f\u0120\3\2\2\2\u0120Z\3"+
		"\2\2\2\u0121\u0122\7/\2\2\u0122\u0123\7/\2\2\u0123\u0127\3\2\2\2\u0124"+
		"\u0126\n\7\2\2\u0125\u0124\3\2\2\2\u0126\u0129\3\2\2\2\u0127\u0125\3\2"+
		"\2\2\u0127\u0128\3\2\2\2\u0128\u012c\3\2\2\2\u0129\u0127\3\2\2\2\u012a"+
		"\u012d\5_\60\2\u012b\u012d\7\2\2\3\u012c\u012a\3\2\2\2\u012c\u012b\3\2"+
		"\2\2\u012d\u012e\3\2\2\2\u012e\u012f\b.\3\2\u012f\\\3\2\2\2\u0130\u0131"+
		"\7\61\2\2\u0131\u0132\7,\2\2\u0132\u0136\3\2\2\2\u0133\u0135\13\2\2\2"+
		"\u0134\u0133\3\2\2\2\u0135\u0138\3\2\2\2\u0136\u0137\3\2\2\2\u0136\u0134"+
		"\3\2\2\2\u0137\u0139\3\2\2\2\u0138\u0136\3\2\2\2\u0139\u013a\7,\2\2\u013a"+
		"\u013b\7\61\2\2\u013b\u013c\3\2\2\2\u013c\u013d\b/\3\2\u013d^\3\2\2\2"+
		"\u013e\u0140\7\17\2\2\u013f\u013e\3\2\2\2\u013f\u0140\3\2\2\2\u0140\u0141"+
		"\3\2\2\2\u0141\u0142\7\f\2\2\u0142`\3\2\2\2\u0143\u0144\t\b\2\2\u0144"+
		"b\3\2\2\2\u0145\u014a\5W,\2\u0146\u0149\5W,\2\u0147\u0149\t\t\2\2\u0148"+
		"\u0146\3\2\2\2\u0148\u0147\3\2\2\2\u0149\u014c\3\2\2\2\u014a\u0148\3\2"+
		"\2\2\u014a\u014b\3\2\2\2\u014bd\3\2\2\2\u014c\u014a\3\2\2\2\17\2\u00cc"+
		"\u00ce\u00d7\u00d9\u0116\u011f\u0127\u012c\u0136\u013f\u0148\u014a\4\b"+
		"\2\2\2\3\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}