// Generated from WorkflowParser.g4 by ANTLR 4.7
// jshint ignore: start
var antlr4 = require('antlr4/index');
var WorkflowParserVisitor = require('./WorkflowParserVisitor').WorkflowParserVisitor;

var grammarFileName = "WorkflowParser.g4";

var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0003/\u0129\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004\u0004\t",
    "\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\u0007\t\u0007\u0004",
    "\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\u000b\t\u000b\u0004\f\t\f\u0004",
    "\r\t\r\u0004\u000e\t\u000e\u0004\u000f\t\u000f\u0004\u0010\t\u0010\u0004",
    "\u0011\t\u0011\u0004\u0012\t\u0012\u0004\u0013\t\u0013\u0004\u0014\t",
    "\u0014\u0004\u0015\t\u0015\u0004\u0016\t\u0016\u0004\u0017\t\u0017\u0004",
    "\u0018\t\u0018\u0004\u0019\t\u0019\u0004\u001a\t\u001a\u0004\u001b\t",
    "\u001b\u0004\u001c\t\u001c\u0003\u0002\u0003\u0002\u0003\u0002\u0003",
    "\u0002\u0005\u0002=\n\u0002\u0003\u0002\u0003\u0002\u0007\u0002A\n\u0002",
    "\f\u0002\u000e\u0002D\u000b\u0002\u0003\u0002\u0003\u0002\u0006\u0002",
    "H\n\u0002\r\u0002\u000e\u0002I\u0005\u0002L\n\u0002\u0003\u0002\u0003",
    "\u0002\u0003\u0002\u0007\u0002Q\n\u0002\f\u0002\u000e\u0002T\u000b\u0002",
    "\u0003\u0002\u0003\u0002\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003",
    "\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0007\u0003`\n\u0003",
    "\f\u0003\u000e\u0003c\u000b\u0003\u0003\u0004\u0003\u0004\u0003\u0004",
    "\u0003\u0004\u0003\u0005\u0003\u0005\u0003\u0006\u0003\u0006\u0003\u0006",
    "\u0003\u0006\u0003\u0006\u0003\u0006\u0005\u0006q\n\u0006\u0003\u0007",
    "\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003\b\u0003\b\u0003",
    "\b\u0003\b\u0005\b|\n\b\u0003\t\u0003\t\u0003\t\u0003\t\u0006\t\u0082",
    "\n\t\r\t\u000e\t\u0083\u0003\n\u0003\n\u0005\n\u0088\n\n\u0003\n\u0003",
    "\n\u0003\n\u0003\n\u0007\n\u008e\n\n\f\n\u000e\n\u0091\u000b\n\u0003",
    "\n\u0007\n\u0094\n\n\f\n\u000e\n\u0097\u000b\n\u0003\u000b\u0003\u000b",
    "\u0003\u000b\u0003\u000b\u0003\u000b\u0003\u000b\u0003\u000b\u0005\u000b",
    "\u00a0\n\u000b\u0003\u000b\u0006\u000b\u00a3\n\u000b\r\u000b\u000e\u000b",
    "\u00a4\u0003\f\u0003\f\u0003\f\u0003\r\u0003\r\u0005\r\u00ac\n\r\u0003",
    "\r\u0007\r\u00af\n\r\f\r\u000e\r\u00b2\u000b\r\u0003\r\u0003\r\u0003",
    "\r\u0003\r\u0005\r\u00b8\n\r\u0003\r\u0003\r\u0003\r\u0006\r\u00bd\n",
    "\r\r\r\u000e\r\u00be\u0005\r\u00c1\n\r\u0003\u000e\u0003\u000e\u0003",
    "\u000e\u0003\u000e\u0003\u000e\u0005\u000e\u00c8\n\u000e\u0003\u000e",
    "\u0003\u000e\u0003\u000e\u0005\u000e\u00cd\n\u000e\u0003\u000e\u0003",
    "\u000e\u0003\u000f\u0003\u000f\u0005\u000f\u00d3\n\u000f\u0003\u000f",
    "\u0003\u000f\u0003\u000f\u0005\u000f\u00d8\n\u000f\u0003\u000f\u0003",
    "\u000f\u0003\u0010\u0003\u0010\u0003\u0010\u0007\u0010\u00df\n\u0010",
    "\f\u0010\u000e\u0010\u00e2\u000b\u0010\u0003\u0011\u0003\u0011\u0003",
    "\u0011\u0005\u0011\u00e7\n\u0011\u0003\u0011\u0003\u0011\u0003\u0012",
    "\u0003\u0012\u0003\u0012\u0007\u0012\u00ee\n\u0012\f\u0012\u000e\u0012",
    "\u00f1\u000b\u0012\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003",
    "\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0005\u0013\u00fb\n\u0013",
    "\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013",
    "\u0007\u0013\u0103\n\u0013\f\u0013\u000e\u0013\u0106\u000b\u0013\u0003",
    "\u0014\u0003\u0014\u0003\u0014\u0003\u0014\u0003\u0015\u0003\u0015\u0003",
    "\u0015\u0003\u0015\u0003\u0016\u0005\u0016\u0111\n\u0016\u0003\u0016",
    "\u0003\u0016\u0003\u0016\u0003\u0016\u0003\u0017\u0003\u0017\u0003\u0018",
    "\u0003\u0018\u0003\u0019\u0003\u0019\u0003\u001a\u0003\u001a\u0003\u001a",
    "\u0003\u001a\u0003\u001b\u0007\u001b\u0122\n\u001b\f\u001b\u000e\u001b",
    "\u0125\u000b\u001b\u0003\u001c\u0003\u001c\u0003\u001c\u0002\u0003$",
    "\u001d\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a",
    "\u001c\u001e \"$&(*,.0246\u0002\u0005\u0004\u0002\u0010\u0010\u0013",
    "\u0013\u0005\u0002\t\t\u0011\u0011\u0015\u0015\u0004\u0002$$//\u0002",
    "\u0134\u00028\u0003\u0002\u0002\u0002\u0004W\u0003\u0002\u0002\u0002",
    "\u0006d\u0003\u0002\u0002\u0002\bh\u0003\u0002\u0002\u0002\nj\u0003",
    "\u0002\u0002\u0002\fr\u0003\u0002\u0002\u0002\u000e{\u0003\u0002\u0002",
    "\u0002\u0010}\u0003\u0002\u0002\u0002\u0012\u0085\u0003\u0002\u0002",
    "\u0002\u0014\u009f\u0003\u0002\u0002\u0002\u0016\u00a6\u0003\u0002\u0002",
    "\u0002\u0018\u00ab\u0003\u0002\u0002\u0002\u001a\u00c2\u0003\u0002\u0002",
    "\u0002\u001c\u00d2\u0003\u0002\u0002\u0002\u001e\u00db\u0003\u0002\u0002",
    "\u0002 \u00e3\u0003\u0002\u0002\u0002\"\u00ea\u0003\u0002\u0002\u0002",
    "$\u00fa\u0003\u0002\u0002\u0002&\u0107\u0003\u0002\u0002\u0002(\u010b",
    "\u0003\u0002\u0002\u0002*\u0110\u0003\u0002\u0002\u0002,\u0116\u0003",
    "\u0002\u0002\u0002.\u0118\u0003\u0002\u0002\u00020\u011a\u0003\u0002",
    "\u0002\u00022\u011c\u0003\u0002\u0002\u00024\u0123\u0003\u0002\u0002",
    "\u00026\u0126\u0003\u0002\u0002\u000289\u0007\u0016\u0002\u00029<\u0005",
    ".\u0018\u0002:;\u0007\b\u0002\u0002;=\u00050\u0019\u0002<:\u0003\u0002",
    "\u0002\u0002<=\u0003\u0002\u0002\u0002=B\u0003\u0002\u0002\u0002>?\u0007",
    "\u0012\u0002\u0002?A\u0007$\u0002\u0002@>\u0003\u0002\u0002\u0002AD",
    "\u0003\u0002\u0002\u0002B@\u0003\u0002\u0002\u0002BC\u0003\u0002\u0002",
    "\u0002CK\u0003\u0002\u0002\u0002DB\u0003\u0002\u0002\u0002EG\u0007\u0014",
    "\u0002\u0002FH\u0005\u0004\u0003\u0002GF\u0003\u0002\u0002\u0002HI\u0003",
    "\u0002\u0002\u0002IG\u0003\u0002\u0002\u0002IJ\u0003\u0002\u0002\u0002",
    "JL\u0003\u0002\u0002\u0002KE\u0003\u0002\u0002\u0002KL\u0003\u0002\u0002",
    "\u0002LR\u0003\u0002\u0002\u0002MN\u0005\b\u0005\u0002NO\u0007(\u0002",
    "\u0002OQ\u0003\u0002\u0002\u0002PM\u0003\u0002\u0002\u0002QT\u0003\u0002",
    "\u0002\u0002RP\u0003\u0002\u0002\u0002RS\u0003\u0002\u0002\u0002SU\u0003",
    "\u0002\u0002\u0002TR\u0003\u0002\u0002\u0002UV\u0007\u0002\u0002\u0003",
    "V\u0003\u0003\u0002\u0002\u0002WX\u0007&\u0002\u0002XY\u0005\u0006\u0004",
    "\u0002Ya\u0007\'\u0002\u0002Z[\u0007)\u0002\u0002[\\\u0007&\u0002\u0002",
    "\\]\u0005\u0006\u0004\u0002]^\u0007\'\u0002\u0002^`\u0003\u0002\u0002",
    "\u0002_Z\u0003\u0002\u0002\u0002`c\u0003\u0002\u0002\u0002a_\u0003\u0002",
    "\u0002\u0002ab\u0003\u0002\u0002\u0002b\u0005\u0003\u0002\u0002\u0002",
    "ca\u0003\u0002\u0002\u0002de\u0005.\u0018\u0002ef\u0007\u000e\u0002",
    "\u0002fg\u0007$\u0002\u0002g\u0007\u0003\u0002\u0002\u0002hi\u0005\n",
    "\u0006\u0002i\t\u0003\u0002\u0002\u0002jp\u0007\n\u0002\u0002kq\u0005",
    "*\u0016\u0002lq\u0005(\u0015\u0002mq\u0005&\u0014\u0002nq\u0005\f\u0007",
    "\u0002oq\u0005\u0010\t\u0002pk\u0003\u0002\u0002\u0002pl\u0003\u0002",
    "\u0002\u0002pm\u0003\u0002\u0002\u0002pn\u0003\u0002\u0002\u0002po\u0003",
    "\u0002\u0002\u0002q\u000b\u0003\u0002\u0002\u0002rs\u0007\u0007\u0002",
    "\u0002st\u0005.\u0018\u0002tu\u0005\u000e\b\u0002uv\u00050\u0019\u0002",
    "v\r\u0003\u0002\u0002\u0002w|\u00056\u001c\u0002x|\u00054\u001b\u0002",
    "y|\u0005\u0016\f\u0002z|\u0007/\u0002\u0002{w\u0003\u0002\u0002\u0002",
    "{x\u0003\u0002\u0002\u0002{y\u0003\u0002\u0002\u0002{z\u0003\u0002\u0002",
    "\u0002|\u000f\u0003\u0002\u0002\u0002}~\u0007\u001e\u0002\u0002~\u007f",
    "\u0005.\u0018\u0002\u007f\u0081\u00050\u0019\u0002\u0080\u0082\u0005",
    "\u0012\n\u0002\u0081\u0080\u0003\u0002\u0002\u0002\u0082\u0083\u0003",
    "\u0002\u0002\u0002\u0083\u0081\u0003\u0002\u0002\u0002\u0083\u0084\u0003",
    "\u0002\u0002\u0002\u0084\u0011\u0003\u0002\u0002\u0002\u0085\u0087\u0007",
    "\"\u0002\u0002\u0086\u0088\t\u0002\u0002\u0002\u0087\u0086\u0003\u0002",
    "\u0002\u0002\u0087\u0088\u0003\u0002\u0002\u0002\u0088\u0089\u0003\u0002",
    "\u0002\u0002\u0089\u008a\u0007\u001f\u0002\u0002\u008a\u008b\u0005.",
    "\u0018\u0002\u008b\u008f\u00050\u0019\u0002\u008c\u008e\u0005\u001a",
    "\u000e\u0002\u008d\u008c\u0003\u0002\u0002\u0002\u008e\u0091\u0003\u0002",
    "\u0002\u0002\u008f\u008d\u0003\u0002\u0002\u0002\u008f\u0090\u0003\u0002",
    "\u0002\u0002\u0090\u0095\u0003\u0002\u0002\u0002\u0091\u008f\u0003\u0002",
    "\u0002\u0002\u0092\u0094\u0005\u0014\u000b\u0002\u0093\u0092\u0003\u0002",
    "\u0002\u0002\u0094\u0097\u0003\u0002\u0002\u0002\u0095\u0093\u0003\u0002",
    "\u0002\u0002\u0095\u0096\u0003\u0002\u0002\u0002\u0096\u0013\u0003\u0002",
    "\u0002\u0002\u0097\u0095\u0003\u0002\u0002\u0002\u0098\u0099\u0007\u0017",
    "\u0002\u0002\u0099\u00a0\u0007\u000b\u0002\u0002\u009a\u009b\u0007\u0019",
    "\u0002\u0002\u009b\u009c\u0007\u000b\u0002\u0002\u009c\u00a0\u0005.",
    "\u0018\u0002\u009d\u009e\u0007\u0004\u0002\u0002\u009e\u00a0\u0005\u0016",
    "\f\u0002\u009f\u0098\u0003\u0002\u0002\u0002\u009f\u009a\u0003\u0002",
    "\u0002\u0002\u009f\u009d\u0003\u0002\u0002\u0002\u00a0\u00a2\u0003\u0002",
    "\u0002\u0002\u00a1\u00a3\u0005\u0018\r\u0002\u00a2\u00a1\u0003\u0002",
    "\u0002\u0002\u00a3\u00a4\u0003\u0002\u0002\u0002\u00a4\u00a2\u0003\u0002",
    "\u0002\u0002\u00a4\u00a5\u0003\u0002\u0002\u0002\u00a5\u0015\u0003\u0002",
    "\u0002\u0002\u00a6\u00a7\u0005,\u0017\u0002\u00a7\u00a8\t\u0003\u0002",
    "\u0002\u00a8\u0017\u0003\u0002\u0002\u0002\u00a9\u00aa\u0007#\u0002",
    "\u0002\u00aa\u00ac\u0005$\u0013\u0002\u00ab\u00a9\u0003\u0002\u0002",
    "\u0002\u00ab\u00ac\u0003\u0002\u0002\u0002\u00ac\u00c0\u0003\u0002\u0002",
    "\u0002\u00ad\u00af\u0005\u001c\u000f\u0002\u00ae\u00ad\u0003\u0002\u0002",
    "\u0002\u00af\u00b2\u0003\u0002\u0002\u0002\u00b0\u00ae\u0003\u0002\u0002",
    "\u0002\u00b0\u00b1\u0003\u0002\u0002\u0002\u00b1\u00b7\u0003\u0002\u0002",
    "\u0002\u00b2\u00b0\u0003\u0002\u0002\u0002\u00b3\u00b4\u0007!\u0002",
    "\u0002\u00b4\u00b5\u0005\u0016\f\u0002\u00b5\u00b6\u0007\u0006\u0002",
    "\u0002\u00b6\u00b8\u0003\u0002\u0002\u0002\u00b7\u00b3\u0003\u0002\u0002",
    "\u0002\u00b7\u00b8\u0003\u0002\u0002\u0002\u00b8\u00b9\u0003\u0002\u0002",
    "\u0002\u00b9\u00ba\u0007\u001d\u0002\u0002\u00ba\u00c1\u0005.\u0018",
    "\u0002\u00bb\u00bd\u0005\u001c\u000f\u0002\u00bc\u00bb\u0003\u0002\u0002",
    "\u0002\u00bd\u00be\u0003\u0002\u0002\u0002\u00be\u00bc\u0003\u0002\u0002",
    "\u0002\u00be\u00bf\u0003\u0002\u0002\u0002\u00bf\u00c1\u0003\u0002\u0002",
    "\u0002\u00c0\u00b0\u0003\u0002\u0002\u0002\u00c0\u00bc\u0003\u0002\u0002",
    "\u0002\u00c1\u0019\u0003\u0002\u0002\u0002\u00c2\u00c7\u0007\u0019\u0002",
    "\u0002\u00c3\u00c8\u0007\r\u0002\u0002\u00c4\u00c8\u0007\u000f\u0002",
    "\u0002\u00c5\u00c6\u0007\r\u0002\u0002\u00c6\u00c8\u0007\u000f\u0002",
    "\u0002\u00c7\u00c3\u0003\u0002\u0002\u0002\u00c7\u00c4\u0003\u0002\u0002",
    "\u0002\u00c7\u00c5\u0003\u0002\u0002\u0002\u00c8\u00c9\u0003\u0002\u0002",
    "\u0002\u00c9\u00ca\u0007\f\u0002\u0002\u00ca\u00cc\u0007&\u0002\u0002",
    "\u00cb\u00cd\u0005\u001e\u0010\u0002\u00cc\u00cb\u0003\u0002\u0002\u0002",
    "\u00cc\u00cd\u0003\u0002\u0002\u0002\u00cd\u00ce\u0003\u0002\u0002\u0002",
    "\u00ce\u00cf\u0007\'\u0002\u0002\u00cf\u001b\u0003\u0002\u0002\u0002",
    "\u00d0\u00d1\u0007\u0019\u0002\u0002\u00d1\u00d3\u0007\u000f\u0002\u0002",
    "\u00d2\u00d0\u0003\u0002\u0002\u0002\u00d2\u00d3\u0003\u0002\u0002\u0002",
    "\u00d3\u00d4\u0003\u0002\u0002\u0002\u00d4\u00d5\u0007\f\u0002\u0002",
    "\u00d5\u00d7\u0007&\u0002\u0002\u00d6\u00d8\u0005\u001e\u0010\u0002",
    "\u00d7\u00d6\u0003\u0002\u0002\u0002\u00d7\u00d8\u0003\u0002\u0002\u0002",
    "\u00d8\u00d9\u0003\u0002\u0002\u0002\u00d9\u00da\u0007\'\u0002\u0002",
    "\u00da\u001d\u0003\u0002\u0002\u0002\u00db\u00e0\u0005 \u0011\u0002",
    "\u00dc\u00dd\u0007)\u0002\u0002\u00dd\u00df\u0005 \u0011\u0002\u00de",
    "\u00dc\u0003\u0002\u0002\u0002\u00df\u00e2\u0003\u0002\u0002\u0002\u00e0",
    "\u00de\u0003\u0002\u0002\u0002\u00e0\u00e1\u0003\u0002\u0002\u0002\u00e1",
    "\u001f\u0003\u0002\u0002\u0002\u00e2\u00e0\u0003\u0002\u0002\u0002\u00e3",
    "\u00e4\u0005.\u0018\u0002\u00e4\u00e6\u0007&\u0002\u0002\u00e5\u00e7",
    "\u0005\"\u0012\u0002\u00e6\u00e5\u0003\u0002\u0002\u0002\u00e6\u00e7",
    "\u0003\u0002\u0002\u0002\u00e7\u00e8\u0003\u0002\u0002\u0002\u00e8\u00e9",
    "\u0007\'\u0002\u0002\u00e9!\u0003\u0002\u0002\u0002\u00ea\u00ef\u0005",
    "6\u001c\u0002\u00eb\u00ec\u0007)\u0002\u0002\u00ec\u00ee\u00056\u001c",
    "\u0002\u00ed\u00eb\u0003\u0002\u0002\u0002\u00ee\u00f1\u0003\u0002\u0002",
    "\u0002\u00ef\u00ed\u0003\u0002\u0002\u0002\u00ef\u00f0\u0003\u0002\u0002",
    "\u0002\u00f0#\u0003\u0002\u0002\u0002\u00f1\u00ef\u0003\u0002\u0002",
    "\u0002\u00f2\u00f3\b\u0013\u0001\u0002\u00f3\u00fb\u0005.\u0018\u0002",
    "\u00f4\u00f5\u0007\u0018\u0002\u0002\u00f5\u00fb\u0005$\u0013\u0006",
    "\u00f6\u00f7\u0007&\u0002\u0002\u00f7\u00f8\u0005$\u0013\u0002\u00f8",
    "\u00f9\u0007\'\u0002\u0002\u00f9\u00fb\u0003\u0002\u0002\u0002\u00fa",
    "\u00f2\u0003\u0002\u0002\u0002\u00fa\u00f4\u0003\u0002\u0002\u0002\u00fa",
    "\u00f6\u0003\u0002\u0002\u0002\u00fb\u0104\u0003\u0002\u0002\u0002\u00fc",
    "\u00fd\f\u0005\u0002\u0002\u00fd\u00fe\u0007\u0005\u0002\u0002\u00fe",
    "\u0103\u0005$\u0013\u0006\u00ff\u0100\f\u0004\u0002\u0002\u0100\u0101",
    "\u0007\u001a\u0002\u0002\u0101\u0103\u0005$\u0013\u0005\u0102\u00fc",
    "\u0003\u0002\u0002\u0002\u0102\u00ff\u0003\u0002\u0002\u0002\u0103\u0106",
    "\u0003\u0002\u0002\u0002\u0104\u0102\u0003\u0002\u0002\u0002\u0104\u0105",
    "\u0003\u0002\u0002\u0002\u0105%\u0003\u0002\u0002\u0002\u0106\u0104",
    "\u0003\u0002\u0002\u0002\u0107\u0108\u0007\u0003\u0002\u0002\u0108\u0109",
    "\u0005.\u0018\u0002\u0109\u010a\u00050\u0019\u0002\u010a\'\u0003\u0002",
    "\u0002\u0002\u010b\u010c\u0007\u001c\u0002\u0002\u010c\u010d\u0005.",
    "\u0018\u0002\u010d\u010e\u00050\u0019\u0002\u010e)\u0003\u0002\u0002",
    "\u0002\u010f\u0111\u0007\u0017\u0002\u0002\u0110\u010f\u0003\u0002\u0002",
    "\u0002\u0110\u0111\u0003\u0002\u0002\u0002\u0111\u0112\u0003\u0002\u0002",
    "\u0002\u0112\u0113\u0007\u000b\u0002\u0002\u0113\u0114\u0005.\u0018",
    "\u0002\u0114\u0115\u00050\u0019\u0002\u0115+\u0003\u0002\u0002\u0002",
    "\u0116\u0117\u0007,\u0002\u0002\u0117-\u0003\u0002\u0002\u0002\u0118",
    "\u0119\t\u0004\u0002\u0002\u0119/\u0003\u0002\u0002\u0002\u011a\u011b",
    "\u0007%\u0002\u0002\u011b1\u0003\u0002\u0002\u0002\u011c\u011d\u0005",
    "4\u001b\u0002\u011d\u011e\u0007*\u0002\u0002\u011e\u011f\u00054\u001b",
    "\u0002\u011f3\u0003\u0002\u0002\u0002\u0120\u0122\u0007,\u0002\u0002",
    "\u0121\u0120\u0003\u0002\u0002\u0002\u0122\u0125\u0003\u0002\u0002\u0002",
    "\u0123\u0121\u0003\u0002\u0002\u0002\u0123\u0124\u0003\u0002\u0002\u0002",
    "\u01245\u0003\u0002\u0002\u0002\u0125\u0123\u0003\u0002\u0002\u0002",
    "\u0126\u0127\u0007$\u0002\u0002\u01277\u0003\u0002\u0002\u0002!<BIK",
    "Rap{\u0083\u0087\u008f\u0095\u009f\u00a4\u00ab\u00b0\u00b7\u00be\u00c0",
    "\u00c7\u00cc\u00d2\u00d7\u00e0\u00e6\u00ef\u00fa\u0102\u0104\u0110\u0123"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

var sharedContextCache = new antlr4.PredictionContextCache();

var literalNames = [ null, "'ACTION'", "'AFTER'", "'AND'", "'BEFORE'", "'CONST'", 
                     "'DESCRIPTION'", "'DAY'", "'DEFINE'", "'EVENT'", "'EXECUTE'", 
                     "'ENTER'", "'='", "'EXIT'", "'FINAL'", "'HOUR'", "'INCLUDE'", 
                     "'INITIAL'", "'MATCHING'", "'MINUTE'", "'NAME'", "'NO'", 
                     "'NOT'", "'ON'", "'OR'", "'PARAMETER'", "'RULE'", "'SWITCH'", 
                     "'SEQUENCE'", "'STATE'", "'TIME'", "'WAITING'", "'WITH'", 
                     "'WHEN'", null, null, "'('", "')'", "';'", "','", "'.'" ];

var symbolicNames = [ null, "ACTION", "AFTER", "AND", "BEFORE", "CONST", 
                      "DESCRIPTION", "DAY", "DEFINE", "EVENT", "EXECUTE", 
                      "ENTER", "EQUAL", "EXIT", "FINAL", "HOUR", "INCLUDE", 
                      "INITIAL", "MATCHING", "MINUTE", "NAME", "NO", "NOT", 
                      "ON", "OR", "PARAMETER", "RULE", "SWITCH", "SEQUENCE", 
                      "STATE", "TIME", "WAITING", "WITH", "WHEN", "CHAR_STRING", 
                      "CHAR_COMMENT", "LEFT_PAREN", "RIGHT_PAREN", "SEMICOLON", 
                      "COMMA", "DOT", "SPACES", "NUMBER", "SINGLE_LINE_COMMENT", 
                      "MULTI_LINE_COMMENT", "REGULAR_ID" ];

var ruleNames =  [ "script", "matchings", "matching", "unit_statement", 
                   "define_statement", "constant", "value", "sequence_statement", 
                   "state", "on_event_statement", "delay", "switch_state", 
                   "execute", "execute2", "actions", "action", "arguments", 
                   "rule_condition", "action_statement", "rule_statement", 
                   "event_statement", "number", "key", "comment", "numeric", 
                   "numbers", "string" ];

function WorkflowParser (input) {
	antlr4.Parser.call(this, input);
    this._interp = new antlr4.atn.ParserATNSimulator(this, atn, decisionsToDFA, sharedContextCache);
    this.ruleNames = ruleNames;
    this.literalNames = literalNames;
    this.symbolicNames = symbolicNames;
    return this;
}

WorkflowParser.prototype = Object.create(antlr4.Parser.prototype);
WorkflowParser.prototype.constructor = WorkflowParser;

Object.defineProperty(WorkflowParser.prototype, "atn", {
	get : function() {
		return atn;
	}
});

WorkflowParser.EOF = antlr4.Token.EOF;
WorkflowParser.ACTION = 1;
WorkflowParser.AFTER = 2;
WorkflowParser.AND = 3;
WorkflowParser.BEFORE = 4;
WorkflowParser.CONST = 5;
WorkflowParser.DESCRIPTION = 6;
WorkflowParser.DAY = 7;
WorkflowParser.DEFINE = 8;
WorkflowParser.EVENT = 9;
WorkflowParser.EXECUTE = 10;
WorkflowParser.ENTER = 11;
WorkflowParser.EQUAL = 12;
WorkflowParser.EXIT = 13;
WorkflowParser.FINAL = 14;
WorkflowParser.HOUR = 15;
WorkflowParser.INCLUDE = 16;
WorkflowParser.INITIAL = 17;
WorkflowParser.MATCHING = 18;
WorkflowParser.MINUTE = 19;
WorkflowParser.NAME = 20;
WorkflowParser.NO = 21;
WorkflowParser.NOT = 22;
WorkflowParser.ON = 23;
WorkflowParser.OR = 24;
WorkflowParser.PARAMETER = 25;
WorkflowParser.RULE = 26;
WorkflowParser.SWITCH = 27;
WorkflowParser.SEQUENCE = 28;
WorkflowParser.STATE = 29;
WorkflowParser.TIME = 30;
WorkflowParser.WAITING = 31;
WorkflowParser.WITH = 32;
WorkflowParser.WHEN = 33;
WorkflowParser.CHAR_STRING = 34;
WorkflowParser.CHAR_COMMENT = 35;
WorkflowParser.LEFT_PAREN = 36;
WorkflowParser.RIGHT_PAREN = 37;
WorkflowParser.SEMICOLON = 38;
WorkflowParser.COMMA = 39;
WorkflowParser.DOT = 40;
WorkflowParser.SPACES = 41;
WorkflowParser.NUMBER = 42;
WorkflowParser.SINGLE_LINE_COMMENT = 43;
WorkflowParser.MULTI_LINE_COMMENT = 44;
WorkflowParser.REGULAR_ID = 45;

WorkflowParser.RULE_script = 0;
WorkflowParser.RULE_matchings = 1;
WorkflowParser.RULE_matching = 2;
WorkflowParser.RULE_unit_statement = 3;
WorkflowParser.RULE_define_statement = 4;
WorkflowParser.RULE_constant = 5;
WorkflowParser.RULE_value = 6;
WorkflowParser.RULE_sequence_statement = 7;
WorkflowParser.RULE_state = 8;
WorkflowParser.RULE_on_event_statement = 9;
WorkflowParser.RULE_delay = 10;
WorkflowParser.RULE_switch_state = 11;
WorkflowParser.RULE_execute = 12;
WorkflowParser.RULE_execute2 = 13;
WorkflowParser.RULE_actions = 14;
WorkflowParser.RULE_action = 15;
WorkflowParser.RULE_arguments = 16;
WorkflowParser.RULE_rule_condition = 17;
WorkflowParser.RULE_action_statement = 18;
WorkflowParser.RULE_rule_statement = 19;
WorkflowParser.RULE_event_statement = 20;
WorkflowParser.RULE_number = 21;
WorkflowParser.RULE_key = 22;
WorkflowParser.RULE_comment = 23;
WorkflowParser.RULE_numeric = 24;
WorkflowParser.RULE_numbers = 25;
WorkflowParser.RULE_string = 26;

function ScriptContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_script;
    return this;
}

ScriptContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ScriptContext.prototype.constructor = ScriptContext;

ScriptContext.prototype.NAME = function() {
    return this.getToken(WorkflowParser.NAME, 0);
};

ScriptContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

ScriptContext.prototype.EOF = function() {
    return this.getToken(WorkflowParser.EOF, 0);
};

ScriptContext.prototype.DESCRIPTION = function() {
    return this.getToken(WorkflowParser.DESCRIPTION, 0);
};

ScriptContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

ScriptContext.prototype.INCLUDE = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.INCLUDE);
    } else {
        return this.getToken(WorkflowParser.INCLUDE, i);
    }
};


ScriptContext.prototype.CHAR_STRING = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.CHAR_STRING);
    } else {
        return this.getToken(WorkflowParser.CHAR_STRING, i);
    }
};


ScriptContext.prototype.MATCHING = function() {
    return this.getToken(WorkflowParser.MATCHING, 0);
};

ScriptContext.prototype.unit_statement = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(Unit_statementContext);
    } else {
        return this.getTypedRuleContext(Unit_statementContext,i);
    }
};

ScriptContext.prototype.SEMICOLON = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.SEMICOLON);
    } else {
        return this.getToken(WorkflowParser.SEMICOLON, i);
    }
};


ScriptContext.prototype.matchings = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(MatchingsContext);
    } else {
        return this.getTypedRuleContext(MatchingsContext,i);
    }
};

ScriptContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitScript(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ScriptContext = ScriptContext;

WorkflowParser.prototype.script = function() {

    var localctx = new ScriptContext(this, this._ctx, this.state);
    this.enterRule(localctx, 0, WorkflowParser.RULE_script);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 54;
        this.match(WorkflowParser.NAME);
        this.state = 55;
        this.key();
        this.state = 58;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.DESCRIPTION) {
            this.state = 56;
            this.match(WorkflowParser.DESCRIPTION);
            this.state = 57;
            this.comment();
        }

        this.state = 64;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.INCLUDE) {
            this.state = 60;
            this.match(WorkflowParser.INCLUDE);
            this.state = 61;
            this.match(WorkflowParser.CHAR_STRING);
            this.state = 66;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
        this.state = 73;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.MATCHING) {
            this.state = 67;
            this.match(WorkflowParser.MATCHING);
            this.state = 69; 
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            do {
                this.state = 68;
                this.matchings();
                this.state = 71; 
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            } while(_la===WorkflowParser.LEFT_PAREN);
        }

        this.state = 80;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.DEFINE) {
            this.state = 75;
            this.unit_statement();
            this.state = 76;
            this.match(WorkflowParser.SEMICOLON);
            this.state = 82;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
        this.state = 83;
        this.match(WorkflowParser.EOF);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function MatchingsContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_matchings;
    return this;
}

MatchingsContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
MatchingsContext.prototype.constructor = MatchingsContext;

MatchingsContext.prototype.LEFT_PAREN = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.LEFT_PAREN);
    } else {
        return this.getToken(WorkflowParser.LEFT_PAREN, i);
    }
};


MatchingsContext.prototype.matching = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(MatchingContext);
    } else {
        return this.getTypedRuleContext(MatchingContext,i);
    }
};

MatchingsContext.prototype.RIGHT_PAREN = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.RIGHT_PAREN);
    } else {
        return this.getToken(WorkflowParser.RIGHT_PAREN, i);
    }
};


MatchingsContext.prototype.COMMA = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.COMMA);
    } else {
        return this.getToken(WorkflowParser.COMMA, i);
    }
};


MatchingsContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitMatchings(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.MatchingsContext = MatchingsContext;

WorkflowParser.prototype.matchings = function() {

    var localctx = new MatchingsContext(this, this._ctx, this.state);
    this.enterRule(localctx, 2, WorkflowParser.RULE_matchings);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 85;
        this.match(WorkflowParser.LEFT_PAREN);
        this.state = 86;
        this.matching();
        this.state = 87;
        this.match(WorkflowParser.RIGHT_PAREN);
        this.state = 95;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.COMMA) {
            this.state = 88;
            this.match(WorkflowParser.COMMA);
            this.state = 89;
            this.match(WorkflowParser.LEFT_PAREN);
            this.state = 90;
            this.matching();
            this.state = 91;
            this.match(WorkflowParser.RIGHT_PAREN);
            this.state = 97;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function MatchingContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_matching;
    return this;
}

MatchingContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
MatchingContext.prototype.constructor = MatchingContext;

MatchingContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

MatchingContext.prototype.EQUAL = function() {
    return this.getToken(WorkflowParser.EQUAL, 0);
};

MatchingContext.prototype.CHAR_STRING = function() {
    return this.getToken(WorkflowParser.CHAR_STRING, 0);
};

MatchingContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitMatching(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.MatchingContext = MatchingContext;

WorkflowParser.prototype.matching = function() {

    var localctx = new MatchingContext(this, this._ctx, this.state);
    this.enterRule(localctx, 4, WorkflowParser.RULE_matching);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 98;
        this.key();
        this.state = 99;
        this.match(WorkflowParser.EQUAL);
        this.state = 100;
        this.match(WorkflowParser.CHAR_STRING);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Unit_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_unit_statement;
    return this;
}

Unit_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Unit_statementContext.prototype.constructor = Unit_statementContext;

Unit_statementContext.prototype.define_statement = function() {
    return this.getTypedRuleContext(Define_statementContext,0);
};

Unit_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitUnit_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Unit_statementContext = Unit_statementContext;

WorkflowParser.prototype.unit_statement = function() {

    var localctx = new Unit_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 6, WorkflowParser.RULE_unit_statement);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 102;
        this.define_statement();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Define_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_define_statement;
    return this;
}

Define_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Define_statementContext.prototype.constructor = Define_statementContext;

Define_statementContext.prototype.DEFINE = function() {
    return this.getToken(WorkflowParser.DEFINE, 0);
};

Define_statementContext.prototype.event_statement = function() {
    return this.getTypedRuleContext(Event_statementContext,0);
};

Define_statementContext.prototype.rule_statement = function() {
    return this.getTypedRuleContext(Rule_statementContext,0);
};

Define_statementContext.prototype.action_statement = function() {
    return this.getTypedRuleContext(Action_statementContext,0);
};

Define_statementContext.prototype.constant = function() {
    return this.getTypedRuleContext(ConstantContext,0);
};

Define_statementContext.prototype.sequence_statement = function() {
    return this.getTypedRuleContext(Sequence_statementContext,0);
};

Define_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitDefine_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Define_statementContext = Define_statementContext;

WorkflowParser.prototype.define_statement = function() {

    var localctx = new Define_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 8, WorkflowParser.RULE_define_statement);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 104;
        this.match(WorkflowParser.DEFINE);
        this.state = 110;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case WorkflowParser.EVENT:
        case WorkflowParser.NO:
            this.state = 105;
            this.event_statement();
            break;
        case WorkflowParser.RULE:
            this.state = 106;
            this.rule_statement();
            break;
        case WorkflowParser.ACTION:
            this.state = 107;
            this.action_statement();
            break;
        case WorkflowParser.CONST:
            this.state = 108;
            this.constant();
            break;
        case WorkflowParser.SEQUENCE:
            this.state = 109;
            this.sequence_statement();
            break;
        default:
            throw new antlr4.error.NoViableAltException(this);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ConstantContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_constant;
    return this;
}

ConstantContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ConstantContext.prototype.constructor = ConstantContext;

ConstantContext.prototype.CONST = function() {
    return this.getToken(WorkflowParser.CONST, 0);
};

ConstantContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

ConstantContext.prototype.value = function() {
    return this.getTypedRuleContext(ValueContext,0);
};

ConstantContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

ConstantContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitConstant(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ConstantContext = ConstantContext;

WorkflowParser.prototype.constant = function() {

    var localctx = new ConstantContext(this, this._ctx, this.state);
    this.enterRule(localctx, 10, WorkflowParser.RULE_constant);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 112;
        this.match(WorkflowParser.CONST);
        this.state = 113;
        this.key();
        this.state = 114;
        this.value();
        this.state = 115;
        this.comment();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ValueContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_value;
    return this;
}

ValueContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ValueContext.prototype.constructor = ValueContext;

ValueContext.prototype.string = function() {
    return this.getTypedRuleContext(StringContext,0);
};

ValueContext.prototype.numbers = function() {
    return this.getTypedRuleContext(NumbersContext,0);
};

ValueContext.prototype.delay = function() {
    return this.getTypedRuleContext(DelayContext,0);
};

ValueContext.prototype.REGULAR_ID = function() {
    return this.getToken(WorkflowParser.REGULAR_ID, 0);
};

ValueContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitValue(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ValueContext = ValueContext;

WorkflowParser.prototype.value = function() {

    var localctx = new ValueContext(this, this._ctx, this.state);
    this.enterRule(localctx, 12, WorkflowParser.RULE_value);
    try {
        this.state = 121;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,7,this._ctx);
        switch(la_) {
        case 1:
            this.enterOuterAlt(localctx, 1);
            this.state = 117;
            this.string();
            break;

        case 2:
            this.enterOuterAlt(localctx, 2);
            this.state = 118;
            this.numbers();
            break;

        case 3:
            this.enterOuterAlt(localctx, 3);
            this.state = 119;
            this.delay();
            break;

        case 4:
            this.enterOuterAlt(localctx, 4);
            this.state = 120;
            this.match(WorkflowParser.REGULAR_ID);
            break;

        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Sequence_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_sequence_statement;
    return this;
}

Sequence_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Sequence_statementContext.prototype.constructor = Sequence_statementContext;

Sequence_statementContext.prototype.SEQUENCE = function() {
    return this.getToken(WorkflowParser.SEQUENCE, 0);
};

Sequence_statementContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Sequence_statementContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

Sequence_statementContext.prototype.state = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(StateContext);
    } else {
        return this.getTypedRuleContext(StateContext,i);
    }
};

Sequence_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitSequence_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Sequence_statementContext = Sequence_statementContext;

WorkflowParser.prototype.sequence_statement = function() {

    var localctx = new Sequence_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 14, WorkflowParser.RULE_sequence_statement);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 123;
        this.match(WorkflowParser.SEQUENCE);
        this.state = 124;
        this.key();
        this.state = 125;
        this.comment();
        this.state = 127; 
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        do {
            this.state = 126;
            this.state();
            this.state = 129; 
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        } while(_la===WorkflowParser.WITH);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function StateContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_state;
    return this;
}

StateContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
StateContext.prototype.constructor = StateContext;

StateContext.prototype.WITH = function() {
    return this.getToken(WorkflowParser.WITH, 0);
};

StateContext.prototype.STATE = function() {
    return this.getToken(WorkflowParser.STATE, 0);
};

StateContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

StateContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

StateContext.prototype.execute = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(ExecuteContext);
    } else {
        return this.getTypedRuleContext(ExecuteContext,i);
    }
};

StateContext.prototype.on_event_statement = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(On_event_statementContext);
    } else {
        return this.getTypedRuleContext(On_event_statementContext,i);
    }
};

StateContext.prototype.INITIAL = function() {
    return this.getToken(WorkflowParser.INITIAL, 0);
};

StateContext.prototype.FINAL = function() {
    return this.getToken(WorkflowParser.FINAL, 0);
};

StateContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitState(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.StateContext = StateContext;

WorkflowParser.prototype.state = function() {

    var localctx = new StateContext(this, this._ctx, this.state);
    this.enterRule(localctx, 16, WorkflowParser.RULE_state);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 131;
        this.match(WorkflowParser.WITH);
        this.state = 133;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.FINAL || _la===WorkflowParser.INITIAL) {
            this.state = 132;
            _la = this._input.LA(1);
            if(!(_la===WorkflowParser.FINAL || _la===WorkflowParser.INITIAL)) {
            this._errHandler.recoverInline(this);
            }
            else {
            	this._errHandler.reportMatch(this);
                this.consume();
            }
        }

        this.state = 135;
        this.match(WorkflowParser.STATE);
        this.state = 136;
        this.key();
        this.state = 137;
        this.comment();
        this.state = 141;
        this._errHandler.sync(this);
        var _alt = this._interp.adaptivePredict(this._input,10,this._ctx)
        while(_alt!=2 && _alt!=antlr4.atn.ATN.INVALID_ALT_NUMBER) {
            if(_alt===1) {
                this.state = 138;
                this.execute(); 
            }
            this.state = 143;
            this._errHandler.sync(this);
            _alt = this._interp.adaptivePredict(this._input,10,this._ctx);
        }

        this.state = 147;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << WorkflowParser.AFTER) | (1 << WorkflowParser.NO) | (1 << WorkflowParser.ON))) !== 0)) {
            this.state = 144;
            this.on_event_statement();
            this.state = 149;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function On_event_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_on_event_statement;
    return this;
}

On_event_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
On_event_statementContext.prototype.constructor = On_event_statementContext;

On_event_statementContext.prototype.NO = function() {
    return this.getToken(WorkflowParser.NO, 0);
};

On_event_statementContext.prototype.EVENT = function() {
    return this.getToken(WorkflowParser.EVENT, 0);
};

On_event_statementContext.prototype.ON = function() {
    return this.getToken(WorkflowParser.ON, 0);
};

On_event_statementContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

On_event_statementContext.prototype.AFTER = function() {
    return this.getToken(WorkflowParser.AFTER, 0);
};

On_event_statementContext.prototype.delay = function() {
    return this.getTypedRuleContext(DelayContext,0);
};

On_event_statementContext.prototype.switch_state = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(Switch_stateContext);
    } else {
        return this.getTypedRuleContext(Switch_stateContext,i);
    }
};

On_event_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitOn_event_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.On_event_statementContext = On_event_statementContext;

WorkflowParser.prototype.on_event_statement = function() {

    var localctx = new On_event_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 18, WorkflowParser.RULE_on_event_statement);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 157;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case WorkflowParser.NO:
            this.state = 150;
            this.match(WorkflowParser.NO);
            this.state = 151;
            this.match(WorkflowParser.EVENT);
            break;
        case WorkflowParser.ON:
            this.state = 152;
            this.match(WorkflowParser.ON);
            this.state = 153;
            this.match(WorkflowParser.EVENT);
            this.state = 154;
            this.key();
            break;
        case WorkflowParser.AFTER:
            this.state = 155;
            this.match(WorkflowParser.AFTER);
            this.state = 156;
            this.delay();
            break;
        default:
            throw new antlr4.error.NoViableAltException(this);
        }
        this.state = 160; 
        this._errHandler.sync(this);
        var _alt = 1;
        do {
        	switch (_alt) {
        	case 1:
        		this.state = 159;
        		this.switch_state();
        		break;
        	default:
        		throw new antlr4.error.NoViableAltException(this);
        	}
        	this.state = 162; 
        	this._errHandler.sync(this);
        	_alt = this._interp.adaptivePredict(this._input,13, this._ctx);
        } while ( _alt!=2 && _alt!=antlr4.atn.ATN.INVALID_ALT_NUMBER );
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function DelayContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_delay;
    return this;
}

DelayContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
DelayContext.prototype.constructor = DelayContext;

DelayContext.prototype.number = function() {
    return this.getTypedRuleContext(NumberContext,0);
};

DelayContext.prototype.MINUTE = function() {
    return this.getToken(WorkflowParser.MINUTE, 0);
};

DelayContext.prototype.HOUR = function() {
    return this.getToken(WorkflowParser.HOUR, 0);
};

DelayContext.prototype.DAY = function() {
    return this.getToken(WorkflowParser.DAY, 0);
};

DelayContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitDelay(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.DelayContext = DelayContext;

WorkflowParser.prototype.delay = function() {

    var localctx = new DelayContext(this, this._ctx, this.state);
    this.enterRule(localctx, 20, WorkflowParser.RULE_delay);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 164;
        this.number();
        this.state = 165;
        _la = this._input.LA(1);
        if(!((((_la) & ~0x1f) == 0 && ((1 << _la) & ((1 << WorkflowParser.DAY) | (1 << WorkflowParser.HOUR) | (1 << WorkflowParser.MINUTE))) !== 0))) {
        this._errHandler.recoverInline(this);
        }
        else {
        	this._errHandler.reportMatch(this);
            this.consume();
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Switch_stateContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_switch_state;
    return this;
}

Switch_stateContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Switch_stateContext.prototype.constructor = Switch_stateContext;

Switch_stateContext.prototype.SWITCH = function() {
    return this.getToken(WorkflowParser.SWITCH, 0);
};

Switch_stateContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Switch_stateContext.prototype.WHEN = function() {
    return this.getToken(WorkflowParser.WHEN, 0);
};

Switch_stateContext.prototype.rule_condition = function() {
    return this.getTypedRuleContext(Rule_conditionContext,0);
};

Switch_stateContext.prototype.execute2 = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(Execute2Context);
    } else {
        return this.getTypedRuleContext(Execute2Context,i);
    }
};

Switch_stateContext.prototype.WAITING = function() {
    return this.getToken(WorkflowParser.WAITING, 0);
};

Switch_stateContext.prototype.delay = function() {
    return this.getTypedRuleContext(DelayContext,0);
};

Switch_stateContext.prototype.BEFORE = function() {
    return this.getToken(WorkflowParser.BEFORE, 0);
};

Switch_stateContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitSwitch_state(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Switch_stateContext = Switch_stateContext;

WorkflowParser.prototype.switch_state = function() {

    var localctx = new Switch_stateContext(this, this._ctx, this.state);
    this.enterRule(localctx, 22, WorkflowParser.RULE_switch_state);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 169;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.WHEN) {
            this.state = 167;
            this.match(WorkflowParser.WHEN);
            this.state = 168;
            this.rule_condition(0);
        }

        this.state = 190;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,18,this._ctx);
        switch(la_) {
        case 1:
            this.state = 174;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            while(_la===WorkflowParser.EXECUTE || _la===WorkflowParser.ON) {
                this.state = 171;
                this.execute2();
                this.state = 176;
                this._errHandler.sync(this);
                _la = this._input.LA(1);
            }
            this.state = 181;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
            if(_la===WorkflowParser.WAITING) {
                this.state = 177;
                this.match(WorkflowParser.WAITING);
                this.state = 178;
                this.delay();
                this.state = 179;
                this.match(WorkflowParser.BEFORE);
            }

            this.state = 183;
            this.match(WorkflowParser.SWITCH);
            this.state = 184;
            this.key();
            break;

        case 2:
            this.state = 186; 
            this._errHandler.sync(this);
            var _alt = 1;
            do {
            	switch (_alt) {
            	case 1:
            		this.state = 185;
            		this.execute2();
            		break;
            	default:
            		throw new antlr4.error.NoViableAltException(this);
            	}
            	this.state = 188; 
            	this._errHandler.sync(this);
            	_alt = this._interp.adaptivePredict(this._input,17, this._ctx);
            } while ( _alt!=2 && _alt!=antlr4.atn.ATN.INVALID_ALT_NUMBER );
            break;

        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ExecuteContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_execute;
    return this;
}

ExecuteContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ExecuteContext.prototype.constructor = ExecuteContext;

ExecuteContext.prototype.ON = function() {
    return this.getToken(WorkflowParser.ON, 0);
};

ExecuteContext.prototype.EXECUTE = function() {
    return this.getToken(WorkflowParser.EXECUTE, 0);
};

ExecuteContext.prototype.LEFT_PAREN = function() {
    return this.getToken(WorkflowParser.LEFT_PAREN, 0);
};

ExecuteContext.prototype.RIGHT_PAREN = function() {
    return this.getToken(WorkflowParser.RIGHT_PAREN, 0);
};

ExecuteContext.prototype.ENTER = function() {
    return this.getToken(WorkflowParser.ENTER, 0);
};

ExecuteContext.prototype.EXIT = function() {
    return this.getToken(WorkflowParser.EXIT, 0);
};

ExecuteContext.prototype.actions = function() {
    return this.getTypedRuleContext(ActionsContext,0);
};

ExecuteContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitExecute(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ExecuteContext = ExecuteContext;

WorkflowParser.prototype.execute = function() {

    var localctx = new ExecuteContext(this, this._ctx, this.state);
    this.enterRule(localctx, 24, WorkflowParser.RULE_execute);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 192;
        this.match(WorkflowParser.ON);
        this.state = 197;
        this._errHandler.sync(this);
        var la_ = this._interp.adaptivePredict(this._input,19,this._ctx);
        switch(la_) {
        case 1:
            this.state = 193;
            this.match(WorkflowParser.ENTER);
            break;

        case 2:
            this.state = 194;
            this.match(WorkflowParser.EXIT);
            break;

        case 3:
            this.state = 195;
            this.match(WorkflowParser.ENTER);
            this.state = 196;
            this.match(WorkflowParser.EXIT);
            break;

        }
        this.state = 199;
        this.match(WorkflowParser.EXECUTE);
        this.state = 200;
        this.match(WorkflowParser.LEFT_PAREN);
        this.state = 202;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.CHAR_STRING || _la===WorkflowParser.REGULAR_ID) {
            this.state = 201;
            this.actions();
        }

        this.state = 204;
        this.match(WorkflowParser.RIGHT_PAREN);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Execute2Context(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_execute2;
    return this;
}

Execute2Context.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Execute2Context.prototype.constructor = Execute2Context;

Execute2Context.prototype.EXECUTE = function() {
    return this.getToken(WorkflowParser.EXECUTE, 0);
};

Execute2Context.prototype.LEFT_PAREN = function() {
    return this.getToken(WorkflowParser.LEFT_PAREN, 0);
};

Execute2Context.prototype.RIGHT_PAREN = function() {
    return this.getToken(WorkflowParser.RIGHT_PAREN, 0);
};

Execute2Context.prototype.ON = function() {
    return this.getToken(WorkflowParser.ON, 0);
};

Execute2Context.prototype.EXIT = function() {
    return this.getToken(WorkflowParser.EXIT, 0);
};

Execute2Context.prototype.actions = function() {
    return this.getTypedRuleContext(ActionsContext,0);
};

Execute2Context.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitExecute2(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Execute2Context = Execute2Context;

WorkflowParser.prototype.execute2 = function() {

    var localctx = new Execute2Context(this, this._ctx, this.state);
    this.enterRule(localctx, 26, WorkflowParser.RULE_execute2);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 208;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.ON) {
            this.state = 206;
            this.match(WorkflowParser.ON);
            this.state = 207;
            this.match(WorkflowParser.EXIT);
        }

        this.state = 210;
        this.match(WorkflowParser.EXECUTE);
        this.state = 211;
        this.match(WorkflowParser.LEFT_PAREN);
        this.state = 213;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.CHAR_STRING || _la===WorkflowParser.REGULAR_ID) {
            this.state = 212;
            this.actions();
        }

        this.state = 215;
        this.match(WorkflowParser.RIGHT_PAREN);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ActionsContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_actions;
    return this;
}

ActionsContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ActionsContext.prototype.constructor = ActionsContext;

ActionsContext.prototype.action = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(ActionContext);
    } else {
        return this.getTypedRuleContext(ActionContext,i);
    }
};

ActionsContext.prototype.COMMA = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.COMMA);
    } else {
        return this.getToken(WorkflowParser.COMMA, i);
    }
};


ActionsContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitActions(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ActionsContext = ActionsContext;

WorkflowParser.prototype.actions = function() {

    var localctx = new ActionsContext(this, this._ctx, this.state);
    this.enterRule(localctx, 28, WorkflowParser.RULE_actions);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 217;
        this.action();
        this.state = 222;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.COMMA) {
            this.state = 218;
            this.match(WorkflowParser.COMMA);
            this.state = 219;
            this.action();
            this.state = 224;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ActionContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_action;
    return this;
}

ActionContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ActionContext.prototype.constructor = ActionContext;

ActionContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

ActionContext.prototype.LEFT_PAREN = function() {
    return this.getToken(WorkflowParser.LEFT_PAREN, 0);
};

ActionContext.prototype.RIGHT_PAREN = function() {
    return this.getToken(WorkflowParser.RIGHT_PAREN, 0);
};

ActionContext.prototype.arguments = function() {
    return this.getTypedRuleContext(ArgumentsContext,0);
};

ActionContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitAction(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ActionContext = ActionContext;

WorkflowParser.prototype.action = function() {

    var localctx = new ActionContext(this, this._ctx, this.state);
    this.enterRule(localctx, 30, WorkflowParser.RULE_action);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 225;
        this.key();
        this.state = 226;
        this.match(WorkflowParser.LEFT_PAREN);
        this.state = 228;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.CHAR_STRING) {
            this.state = 227;
            this.arguments();
        }

        this.state = 230;
        this.match(WorkflowParser.RIGHT_PAREN);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function ArgumentsContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_arguments;
    return this;
}

ArgumentsContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
ArgumentsContext.prototype.constructor = ArgumentsContext;

ArgumentsContext.prototype.string = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(StringContext);
    } else {
        return this.getTypedRuleContext(StringContext,i);
    }
};

ArgumentsContext.prototype.COMMA = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.COMMA);
    } else {
        return this.getToken(WorkflowParser.COMMA, i);
    }
};


ArgumentsContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitArguments(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.ArgumentsContext = ArgumentsContext;

WorkflowParser.prototype.arguments = function() {

    var localctx = new ArgumentsContext(this, this._ctx, this.state);
    this.enterRule(localctx, 32, WorkflowParser.RULE_arguments);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 232;
        this.string();
        this.state = 237;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.COMMA) {
            this.state = 233;
            this.match(WorkflowParser.COMMA);
            this.state = 234;
            this.string();
            this.state = 239;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Rule_conditionContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_rule_condition;
    return this;
}

Rule_conditionContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Rule_conditionContext.prototype.constructor = Rule_conditionContext;

Rule_conditionContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Rule_conditionContext.prototype.NOT = function() {
    return this.getToken(WorkflowParser.NOT, 0);
};

Rule_conditionContext.prototype.rule_condition = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(Rule_conditionContext);
    } else {
        return this.getTypedRuleContext(Rule_conditionContext,i);
    }
};

Rule_conditionContext.prototype.LEFT_PAREN = function() {
    return this.getToken(WorkflowParser.LEFT_PAREN, 0);
};

Rule_conditionContext.prototype.RIGHT_PAREN = function() {
    return this.getToken(WorkflowParser.RIGHT_PAREN, 0);
};

Rule_conditionContext.prototype.AND = function() {
    return this.getToken(WorkflowParser.AND, 0);
};

Rule_conditionContext.prototype.OR = function() {
    return this.getToken(WorkflowParser.OR, 0);
};

Rule_conditionContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitRule_condition(this);
    } else {
        return visitor.visitChildren(this);
    }
};



WorkflowParser.prototype.rule_condition = function(_p) {
	if(_p===undefined) {
	    _p = 0;
	}
    var _parentctx = this._ctx;
    var _parentState = this.state;
    var localctx = new Rule_conditionContext(this, this._ctx, _parentState);
    var _prevctx = localctx;
    var _startState = 34;
    this.enterRecursionRule(localctx, 34, WorkflowParser.RULE_rule_condition, _p);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 248;
        this._errHandler.sync(this);
        switch(this._input.LA(1)) {
        case WorkflowParser.CHAR_STRING:
        case WorkflowParser.REGULAR_ID:
            this.state = 241;
            this.key();
            break;
        case WorkflowParser.NOT:
            this.state = 242;
            this.match(WorkflowParser.NOT);
            this.state = 243;
            this.rule_condition(4);
            break;
        case WorkflowParser.LEFT_PAREN:
            this.state = 244;
            this.match(WorkflowParser.LEFT_PAREN);
            this.state = 245;
            this.rule_condition(0);
            this.state = 246;
            this.match(WorkflowParser.RIGHT_PAREN);
            break;
        default:
            throw new antlr4.error.NoViableAltException(this);
        }
        this._ctx.stop = this._input.LT(-1);
        this.state = 258;
        this._errHandler.sync(this);
        var _alt = this._interp.adaptivePredict(this._input,28,this._ctx)
        while(_alt!=2 && _alt!=antlr4.atn.ATN.INVALID_ALT_NUMBER) {
            if(_alt===1) {
                if(this._parseListeners!==null) {
                    this.triggerExitRuleEvent();
                }
                _prevctx = localctx;
                this.state = 256;
                this._errHandler.sync(this);
                var la_ = this._interp.adaptivePredict(this._input,27,this._ctx);
                switch(la_) {
                case 1:
                    localctx = new Rule_conditionContext(this, _parentctx, _parentState);
                    this.pushNewRecursionContext(localctx, _startState, WorkflowParser.RULE_rule_condition);
                    this.state = 250;
                    if (!( this.precpred(this._ctx, 3))) {
                        throw new antlr4.error.FailedPredicateException(this, "this.precpred(this._ctx, 3)");
                    }
                    this.state = 251;
                    this.match(WorkflowParser.AND);
                    this.state = 252;
                    this.rule_condition(4);
                    break;

                case 2:
                    localctx = new Rule_conditionContext(this, _parentctx, _parentState);
                    this.pushNewRecursionContext(localctx, _startState, WorkflowParser.RULE_rule_condition);
                    this.state = 253;
                    if (!( this.precpred(this._ctx, 2))) {
                        throw new antlr4.error.FailedPredicateException(this, "this.precpred(this._ctx, 2)");
                    }
                    this.state = 254;
                    this.match(WorkflowParser.OR);
                    this.state = 255;
                    this.rule_condition(3);
                    break;

                } 
            }
            this.state = 260;
            this._errHandler.sync(this);
            _alt = this._interp.adaptivePredict(this._input,28,this._ctx);
        }

    } catch( error) {
        if(error instanceof antlr4.error.RecognitionException) {
	        localctx.exception = error;
	        this._errHandler.reportError(this, error);
	        this._errHandler.recover(this, error);
	    } else {
	    	throw error;
	    }
    } finally {
        this.unrollRecursionContexts(_parentctx)
    }
    return localctx;
};

function Action_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_action_statement;
    return this;
}

Action_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Action_statementContext.prototype.constructor = Action_statementContext;

Action_statementContext.prototype.ACTION = function() {
    return this.getToken(WorkflowParser.ACTION, 0);
};

Action_statementContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Action_statementContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

Action_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitAction_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Action_statementContext = Action_statementContext;

WorkflowParser.prototype.action_statement = function() {

    var localctx = new Action_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 36, WorkflowParser.RULE_action_statement);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 261;
        this.match(WorkflowParser.ACTION);
        this.state = 262;
        this.key();
        this.state = 263;
        this.comment();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Rule_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_rule_statement;
    return this;
}

Rule_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Rule_statementContext.prototype.constructor = Rule_statementContext;

Rule_statementContext.prototype.RULE = function() {
    return this.getToken(WorkflowParser.RULE, 0);
};

Rule_statementContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Rule_statementContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

Rule_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitRule_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Rule_statementContext = Rule_statementContext;

WorkflowParser.prototype.rule_statement = function() {

    var localctx = new Rule_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 38, WorkflowParser.RULE_rule_statement);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 265;
        this.match(WorkflowParser.RULE);
        this.state = 266;
        this.key();
        this.state = 267;
        this.comment();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function Event_statementContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_event_statement;
    return this;
}

Event_statementContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
Event_statementContext.prototype.constructor = Event_statementContext;

Event_statementContext.prototype.EVENT = function() {
    return this.getToken(WorkflowParser.EVENT, 0);
};

Event_statementContext.prototype.key = function() {
    return this.getTypedRuleContext(KeyContext,0);
};

Event_statementContext.prototype.comment = function() {
    return this.getTypedRuleContext(CommentContext,0);
};

Event_statementContext.prototype.NO = function() {
    return this.getToken(WorkflowParser.NO, 0);
};

Event_statementContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitEvent_statement(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.Event_statementContext = Event_statementContext;

WorkflowParser.prototype.event_statement = function() {

    var localctx = new Event_statementContext(this, this._ctx, this.state);
    this.enterRule(localctx, 40, WorkflowParser.RULE_event_statement);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 270;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        if(_la===WorkflowParser.NO) {
            this.state = 269;
            this.match(WorkflowParser.NO);
        }

        this.state = 272;
        this.match(WorkflowParser.EVENT);
        this.state = 273;
        this.key();
        this.state = 274;
        this.comment();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function NumberContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_number;
    return this;
}

NumberContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
NumberContext.prototype.constructor = NumberContext;

NumberContext.prototype.NUMBER = function() {
    return this.getToken(WorkflowParser.NUMBER, 0);
};

NumberContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitNumber(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.NumberContext = NumberContext;

WorkflowParser.prototype.number = function() {

    var localctx = new NumberContext(this, this._ctx, this.state);
    this.enterRule(localctx, 42, WorkflowParser.RULE_number);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 276;
        this.match(WorkflowParser.NUMBER);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function KeyContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_key;
    return this;
}

KeyContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
KeyContext.prototype.constructor = KeyContext;

KeyContext.prototype.CHAR_STRING = function() {
    return this.getToken(WorkflowParser.CHAR_STRING, 0);
};

KeyContext.prototype.REGULAR_ID = function() {
    return this.getToken(WorkflowParser.REGULAR_ID, 0);
};

KeyContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitKey(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.KeyContext = KeyContext;

WorkflowParser.prototype.key = function() {

    var localctx = new KeyContext(this, this._ctx, this.state);
    this.enterRule(localctx, 44, WorkflowParser.RULE_key);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 278;
        _la = this._input.LA(1);
        if(!(_la===WorkflowParser.CHAR_STRING || _la===WorkflowParser.REGULAR_ID)) {
        this._errHandler.recoverInline(this);
        }
        else {
        	this._errHandler.reportMatch(this);
            this.consume();
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function CommentContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_comment;
    return this;
}

CommentContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
CommentContext.prototype.constructor = CommentContext;

CommentContext.prototype.CHAR_COMMENT = function() {
    return this.getToken(WorkflowParser.CHAR_COMMENT, 0);
};

CommentContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitComment(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.CommentContext = CommentContext;

WorkflowParser.prototype.comment = function() {

    var localctx = new CommentContext(this, this._ctx, this.state);
    this.enterRule(localctx, 46, WorkflowParser.RULE_comment);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 280;
        this.match(WorkflowParser.CHAR_COMMENT);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function NumericContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_numeric;
    return this;
}

NumericContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
NumericContext.prototype.constructor = NumericContext;

NumericContext.prototype.numbers = function(i) {
    if(i===undefined) {
        i = null;
    }
    if(i===null) {
        return this.getTypedRuleContexts(NumbersContext);
    } else {
        return this.getTypedRuleContext(NumbersContext,i);
    }
};

NumericContext.prototype.DOT = function() {
    return this.getToken(WorkflowParser.DOT, 0);
};

NumericContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitNumeric(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.NumericContext = NumericContext;

WorkflowParser.prototype.numeric = function() {

    var localctx = new NumericContext(this, this._ctx, this.state);
    this.enterRule(localctx, 48, WorkflowParser.RULE_numeric);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 282;
        this.numbers();

        this.state = 283;
        this.match(WorkflowParser.DOT);
        this.state = 284;
        this.numbers();
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function NumbersContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_numbers;
    return this;
}

NumbersContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
NumbersContext.prototype.constructor = NumbersContext;

NumbersContext.prototype.NUMBER = function(i) {
	if(i===undefined) {
		i = null;
	}
    if(i===null) {
        return this.getTokens(WorkflowParser.NUMBER);
    } else {
        return this.getToken(WorkflowParser.NUMBER, i);
    }
};


NumbersContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitNumbers(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.NumbersContext = NumbersContext;

WorkflowParser.prototype.numbers = function() {

    var localctx = new NumbersContext(this, this._ctx, this.state);
    this.enterRule(localctx, 50, WorkflowParser.RULE_numbers);
    var _la = 0; // Token type
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 289;
        this._errHandler.sync(this);
        _la = this._input.LA(1);
        while(_la===WorkflowParser.NUMBER) {
            this.state = 286;
            this.match(WorkflowParser.NUMBER);
            this.state = 291;
            this._errHandler.sync(this);
            _la = this._input.LA(1);
        }
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};

function StringContext(parser, parent, invokingState) {
	if(parent===undefined) {
	    parent = null;
	}
	if(invokingState===undefined || invokingState===null) {
		invokingState = -1;
	}
	antlr4.ParserRuleContext.call(this, parent, invokingState);
    this.parser = parser;
    this.ruleIndex = WorkflowParser.RULE_string;
    return this;
}

StringContext.prototype = Object.create(antlr4.ParserRuleContext.prototype);
StringContext.prototype.constructor = StringContext;

StringContext.prototype.CHAR_STRING = function() {
    return this.getToken(WorkflowParser.CHAR_STRING, 0);
};

StringContext.prototype.accept = function(visitor) {
    if ( visitor instanceof WorkflowParserVisitor ) {
        return visitor.visitString(this);
    } else {
        return visitor.visitChildren(this);
    }
};




WorkflowParser.StringContext = StringContext;

WorkflowParser.prototype.string = function() {

    var localctx = new StringContext(this, this._ctx, this.state);
    this.enterRule(localctx, 52, WorkflowParser.RULE_string);
    try {
        this.enterOuterAlt(localctx, 1);
        this.state = 292;
        this.match(WorkflowParser.CHAR_STRING);
    } catch (re) {
    	if(re instanceof antlr4.error.RecognitionException) {
	        localctx.exception = re;
	        this._errHandler.reportError(this, re);
	        this._errHandler.recover(this, re);
	    } else {
	    	throw re;
	    }
    } finally {
        this.exitRule();
    }
    return localctx;
};


WorkflowParser.prototype.sempred = function(localctx, ruleIndex, predIndex) {
	switch(ruleIndex) {
	case 17:
			return this.rule_condition_sempred(localctx, predIndex);
    default:
        throw "No predicate with index:" + ruleIndex;
   }
};

WorkflowParser.prototype.rule_condition_sempred = function(localctx, predIndex) {
	switch(predIndex) {
		case 0:
			return this.precpred(this._ctx, 3);
		case 1:
			return this.precpred(this._ctx, 2);
		default:
			throw "No predicate with index:" + predIndex;
	}
};


exports.WorkflowParser = WorkflowParser;
