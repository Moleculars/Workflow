// Generated from ..\WorkflowLexer.g4 by ANTLR 4.7
// jshint ignore: start
var antlr4 = require('antlr4/index');


var serializedATN = ["\u0003\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964",
    "\u0002/\u0187\b\u0001\u0004\u0002\t\u0002\u0004\u0003\t\u0003\u0004",
    "\u0004\t\u0004\u0004\u0005\t\u0005\u0004\u0006\t\u0006\u0004\u0007\t",
    "\u0007\u0004\b\t\b\u0004\t\t\t\u0004\n\t\n\u0004\u000b\t\u000b\u0004",
    "\f\t\f\u0004\r\t\r\u0004\u000e\t\u000e\u0004\u000f\t\u000f\u0004\u0010",
    "\t\u0010\u0004\u0011\t\u0011\u0004\u0012\t\u0012\u0004\u0013\t\u0013",
    "\u0004\u0014\t\u0014\u0004\u0015\t\u0015\u0004\u0016\t\u0016\u0004\u0017",
    "\t\u0017\u0004\u0018\t\u0018\u0004\u0019\t\u0019\u0004\u001a\t\u001a",
    "\u0004\u001b\t\u001b\u0004\u001c\t\u001c\u0004\u001d\t\u001d\u0004\u001e",
    "\t\u001e\u0004\u001f\t\u001f\u0004 \t \u0004!\t!\u0004\"\t\"\u0004#",
    "\t#\u0004$\t$\u0004%\t%\u0004&\t&\u0004\'\t\'\u0004(\t(\u0004)\t)\u0004",
    "*\t*\u0004+\t+\u0004,\t,\u0004-\t-\u0004.\t.\u0004/\t/\u00040\t0\u0004",
    "1\t1\u0003\u0002\u0003\u0002\u0003\u0002\u0003\u0002\u0003\u0002\u0003",
    "\u0002\u0003\u0002\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003\u0003",
    "\u0003\u0003\u0003\u0003\u0004\u0003\u0004\u0003\u0004\u0003\u0004\u0003",
    "\u0005\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0005\u0003\u0005\u0003",
    "\u0005\u0003\u0006\u0003\u0006\u0003\u0006\u0003\u0006\u0003\u0006\u0003",
    "\u0006\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003",
    "\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003\u0007\u0003",
    "\u0007\u0003\b\u0003\b\u0003\b\u0003\b\u0003\t\u0003\t\u0003\t\u0003",
    "\t\u0003\t\u0003\t\u0003\t\u0003\n\u0003\n\u0003\n\u0003\n\u0003\n\u0003",
    "\n\u0003\u000b\u0003\u000b\u0003\u000b\u0003\u000b\u0003\u000b\u0003",
    "\u000b\u0003\u000b\u0003\u000b\u0003\f\u0003\f\u0003\f\u0003\f\u0003",
    "\f\u0003\f\u0003\r\u0003\r\u0003\u000e\u0003\u000e\u0003\u000e\u0003",
    "\u000e\u0003\u000e\u0003\u000f\u0003\u000f\u0003\u000f\u0003\u000f\u0003",
    "\u000f\u0003\u000f\u0003\u0010\u0003\u0010\u0003\u0010\u0003\u0010\u0003",
    "\u0010\u0003\u0011\u0003\u0011\u0003\u0011\u0003\u0011\u0003\u0011\u0003",
    "\u0011\u0003\u0011\u0003\u0011\u0003\u0012\u0003\u0012\u0003\u0012\u0003",
    "\u0012\u0003\u0012\u0003\u0012\u0003\u0012\u0003\u0012\u0003\u0013\u0003",
    "\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003\u0013\u0003",
    "\u0013\u0003\u0013\u0003\u0014\u0003\u0014\u0003\u0014\u0003\u0014\u0003",
    "\u0014\u0003\u0014\u0003\u0014\u0003\u0015\u0003\u0015\u0003\u0015\u0003",
    "\u0015\u0003\u0015\u0003\u0016\u0003\u0016\u0003\u0016\u0003\u0017\u0003",
    "\u0017\u0003\u0017\u0003\u0017\u0003\u0018\u0003\u0018\u0003\u0018\u0003",
    "\u0019\u0003\u0019\u0003\u0019\u0003\u001a\u0003\u001a\u0003\u001a\u0003",
    "\u001a\u0003\u001a\u0003\u001a\u0003\u001a\u0003\u001a\u0003\u001a\u0003",
    "\u001a\u0003\u001b\u0003\u001b\u0003\u001b\u0003\u001b\u0003\u001b\u0003",
    "\u001c\u0003\u001c\u0003\u001c\u0003\u001c\u0003\u001c\u0003\u001c\u0003",
    "\u001c\u0003\u001d\u0003\u001d\u0003\u001d\u0003\u001d\u0003\u001d\u0003",
    "\u001d\u0003\u001d\u0003\u001d\u0003\u001d\u0003\u001e\u0003\u001e\u0003",
    "\u001e\u0003\u001e\u0003\u001e\u0003\u001e\u0003\u001f\u0003\u001f\u0003",
    "\u001f\u0003\u001f\u0003\u001f\u0003 \u0003 \u0003 \u0003 \u0003 \u0003",
    " \u0003 \u0003 \u0003!\u0003!\u0003!\u0003!\u0003!\u0003\"\u0003\"\u0003",
    "\"\u0003\"\u0003\"\u0003#\u0003#\u0003#\u0003#\u0003#\u0006#\u0132\n",
    "#\r#\u000e#\u0133\u0003#\u0003#\u0003$\u0003$\u0003$\u0003$\u0003$\u0007",
    "$\u013d\n$\f$\u000e$\u0140\u000b$\u0003$\u0003$\u0003%\u0003%\u0003",
    "&\u0003&\u0003\'\u0003\'\u0003(\u0003(\u0003)\u0003)\u0003*\u0006*\u014f",
    "\n*\r*\u000e*\u0150\u0003*\u0003*\u0003+\u0003+\u0003,\u0006,\u0158",
    "\n,\r,\u000e,\u0159\u0003-\u0003-\u0003-\u0003-\u0007-\u0160\n-\f-\u000e",
    "-\u0163\u000b-\u0003-\u0003-\u0005-\u0167\n-\u0003-\u0003-\u0003.\u0003",
    ".\u0003.\u0003.\u0007.\u016f\n.\f.\u000e.\u0172\u000b.\u0003.\u0003",
    ".\u0003.\u0003.\u0003.\u0003/\u0005/\u017a\n/\u0003/\u0003/\u00030\u0003",
    "0\u00031\u00031\u00031\u00071\u0183\n1\f1\u000e1\u0186\u000b1\u0003",
    "\u0170\u00022\u0003\u0003\u0005\u0004\u0007\u0005\t\u0006\u000b\u0007",
    "\r\b\u000f\t\u0011\n\u0013\u000b\u0015\f\u0017\r\u0019\u000e\u001b\u000f",
    "\u001d\u0010\u001f\u0011!\u0012#\u0013%\u0014\'\u0015)\u0016+\u0017",
    "-\u0018/\u00191\u001a3\u001b5\u001c7\u001d9\u001e;\u001f= ?!A\"C#E$",
    "G%I&K\'M(O)Q*S+U\u0002W,Y-[.]\u0002_\u0002a/\u0003\u0002\n\u0005\u0002",
    "\f\f\u000f\u000f))\u0005\u0002\f\f\u000f\u000f$$\u0005\u0002\u000b\f",
    "\u000f\u000f\"\"\u0004\u0002C\\c|\u0003\u00022;\u0004\u0002\f\f\u000f",
    "\u000f\u0004\u0002\u000b\u000b\"\"\u0005\u0002%&2;aa\u0002\u0191\u0002",
    "\u0003\u0003\u0002\u0002\u0002\u0002\u0005\u0003\u0002\u0002\u0002\u0002",
    "\u0007\u0003\u0002\u0002\u0002\u0002\t\u0003\u0002\u0002\u0002\u0002",
    "\u000b\u0003\u0002\u0002\u0002\u0002\r\u0003\u0002\u0002\u0002\u0002",
    "\u000f\u0003\u0002\u0002\u0002\u0002\u0011\u0003\u0002\u0002\u0002\u0002",
    "\u0013\u0003\u0002\u0002\u0002\u0002\u0015\u0003\u0002\u0002\u0002\u0002",
    "\u0017\u0003\u0002\u0002\u0002\u0002\u0019\u0003\u0002\u0002\u0002\u0002",
    "\u001b\u0003\u0002\u0002\u0002\u0002\u001d\u0003\u0002\u0002\u0002\u0002",
    "\u001f\u0003\u0002\u0002\u0002\u0002!\u0003\u0002\u0002\u0002\u0002",
    "#\u0003\u0002\u0002\u0002\u0002%\u0003\u0002\u0002\u0002\u0002\'\u0003",
    "\u0002\u0002\u0002\u0002)\u0003\u0002\u0002\u0002\u0002+\u0003\u0002",
    "\u0002\u0002\u0002-\u0003\u0002\u0002\u0002\u0002/\u0003\u0002\u0002",
    "\u0002\u00021\u0003\u0002\u0002\u0002\u00023\u0003\u0002\u0002\u0002",
    "\u00025\u0003\u0002\u0002\u0002\u00027\u0003\u0002\u0002\u0002\u0002",
    "9\u0003\u0002\u0002\u0002\u0002;\u0003\u0002\u0002\u0002\u0002=\u0003",
    "\u0002\u0002\u0002\u0002?\u0003\u0002\u0002\u0002\u0002A\u0003\u0002",
    "\u0002\u0002\u0002C\u0003\u0002\u0002\u0002\u0002E\u0003\u0002\u0002",
    "\u0002\u0002G\u0003\u0002\u0002\u0002\u0002I\u0003\u0002\u0002\u0002",
    "\u0002K\u0003\u0002\u0002\u0002\u0002M\u0003\u0002\u0002\u0002\u0002",
    "O\u0003\u0002\u0002\u0002\u0002Q\u0003\u0002\u0002\u0002\u0002S\u0003",
    "\u0002\u0002\u0002\u0002W\u0003\u0002\u0002\u0002\u0002Y\u0003\u0002",
    "\u0002\u0002\u0002[\u0003\u0002\u0002\u0002\u0002a\u0003\u0002\u0002",
    "\u0002\u0003c\u0003\u0002\u0002\u0002\u0005j\u0003\u0002\u0002\u0002",
    "\u0007p\u0003\u0002\u0002\u0002\tt\u0003\u0002\u0002\u0002\u000b{\u0003",
    "\u0002\u0002\u0002\r\u0081\u0003\u0002\u0002\u0002\u000f\u008d\u0003",
    "\u0002\u0002\u0002\u0011\u0091\u0003\u0002\u0002\u0002\u0013\u0098\u0003",
    "\u0002\u0002\u0002\u0015\u009e\u0003\u0002\u0002\u0002\u0017\u00a6\u0003",
    "\u0002\u0002\u0002\u0019\u00ac\u0003\u0002\u0002\u0002\u001b\u00ae\u0003",
    "\u0002\u0002\u0002\u001d\u00b3\u0003\u0002\u0002\u0002\u001f\u00b9\u0003",
    "\u0002\u0002\u0002!\u00be\u0003\u0002\u0002\u0002#\u00c6\u0003\u0002",
    "\u0002\u0002%\u00ce\u0003\u0002\u0002\u0002\'\u00d7\u0003\u0002\u0002",
    "\u0002)\u00de\u0003\u0002\u0002\u0002+\u00e3\u0003\u0002\u0002\u0002",
    "-\u00e6\u0003\u0002\u0002\u0002/\u00ea\u0003\u0002\u0002\u00021\u00ed",
    "\u0003\u0002\u0002\u00023\u00f0\u0003\u0002\u0002\u00025\u00fa\u0003",
    "\u0002\u0002\u00027\u00ff\u0003\u0002\u0002\u00029\u0106\u0003\u0002",
    "\u0002\u0002;\u010f\u0003\u0002\u0002\u0002=\u0115\u0003\u0002\u0002",
    "\u0002?\u011a\u0003\u0002\u0002\u0002A\u0122\u0003\u0002\u0002\u0002",
    "C\u0127\u0003\u0002\u0002\u0002E\u012c\u0003\u0002\u0002\u0002G\u0137",
    "\u0003\u0002\u0002\u0002I\u0143\u0003\u0002\u0002\u0002K\u0145\u0003",
    "\u0002\u0002\u0002M\u0147\u0003\u0002\u0002\u0002O\u0149\u0003\u0002",
    "\u0002\u0002Q\u014b\u0003\u0002\u0002\u0002S\u014e\u0003\u0002\u0002",
    "\u0002U\u0154\u0003\u0002\u0002\u0002W\u0157\u0003\u0002\u0002\u0002",
    "Y\u015b\u0003\u0002\u0002\u0002[\u016a\u0003\u0002\u0002\u0002]\u0179",
    "\u0003\u0002\u0002\u0002_\u017d\u0003\u0002\u0002\u0002a\u017f\u0003",
    "\u0002\u0002\u0002cd\u0007C\u0002\u0002de\u0007E\u0002\u0002ef\u0007",
    "V\u0002\u0002fg\u0007K\u0002\u0002gh\u0007Q\u0002\u0002hi\u0007P\u0002",
    "\u0002i\u0004\u0003\u0002\u0002\u0002jk\u0007C\u0002\u0002kl\u0007H",
    "\u0002\u0002lm\u0007V\u0002\u0002mn\u0007G\u0002\u0002no\u0007T\u0002",
    "\u0002o\u0006\u0003\u0002\u0002\u0002pq\u0007C\u0002\u0002qr\u0007P",
    "\u0002\u0002rs\u0007F\u0002\u0002s\b\u0003\u0002\u0002\u0002tu\u0007",
    "D\u0002\u0002uv\u0007G\u0002\u0002vw\u0007H\u0002\u0002wx\u0007Q\u0002",
    "\u0002xy\u0007T\u0002\u0002yz\u0007G\u0002\u0002z\n\u0003\u0002\u0002",
    "\u0002{|\u0007E\u0002\u0002|}\u0007Q\u0002\u0002}~\u0007P\u0002\u0002",
    "~\u007f\u0007U\u0002\u0002\u007f\u0080\u0007V\u0002\u0002\u0080\f\u0003",
    "\u0002\u0002\u0002\u0081\u0082\u0007F\u0002\u0002\u0082\u0083\u0007",
    "G\u0002\u0002\u0083\u0084\u0007U\u0002\u0002\u0084\u0085\u0007E\u0002",
    "\u0002\u0085\u0086\u0007T\u0002\u0002\u0086\u0087\u0007K\u0002\u0002",
    "\u0087\u0088\u0007R\u0002\u0002\u0088\u0089\u0007V\u0002\u0002\u0089",
    "\u008a\u0007K\u0002\u0002\u008a\u008b\u0007Q\u0002\u0002\u008b\u008c",
    "\u0007P\u0002\u0002\u008c\u000e\u0003\u0002\u0002\u0002\u008d\u008e",
    "\u0007F\u0002\u0002\u008e\u008f\u0007C\u0002\u0002\u008f\u0090\u0007",
    "[\u0002\u0002\u0090\u0010\u0003\u0002\u0002\u0002\u0091\u0092\u0007",
    "F\u0002\u0002\u0092\u0093\u0007G\u0002\u0002\u0093\u0094\u0007H\u0002",
    "\u0002\u0094\u0095\u0007K\u0002\u0002\u0095\u0096\u0007P\u0002\u0002",
    "\u0096\u0097\u0007G\u0002\u0002\u0097\u0012\u0003\u0002\u0002\u0002",
    "\u0098\u0099\u0007G\u0002\u0002\u0099\u009a\u0007X\u0002\u0002\u009a",
    "\u009b\u0007G\u0002\u0002\u009b\u009c\u0007P\u0002\u0002\u009c\u009d",
    "\u0007V\u0002\u0002\u009d\u0014\u0003\u0002\u0002\u0002\u009e\u009f",
    "\u0007G\u0002\u0002\u009f\u00a0\u0007Z\u0002\u0002\u00a0\u00a1\u0007",
    "G\u0002\u0002\u00a1\u00a2\u0007E\u0002\u0002\u00a2\u00a3\u0007W\u0002",
    "\u0002\u00a3\u00a4\u0007V\u0002\u0002\u00a4\u00a5\u0007G\u0002\u0002",
    "\u00a5\u0016\u0003\u0002\u0002\u0002\u00a6\u00a7\u0007G\u0002\u0002",
    "\u00a7\u00a8\u0007P\u0002\u0002\u00a8\u00a9\u0007V\u0002\u0002\u00a9",
    "\u00aa\u0007G\u0002\u0002\u00aa\u00ab\u0007T\u0002\u0002\u00ab\u0018",
    "\u0003\u0002\u0002\u0002\u00ac\u00ad\u0007?\u0002\u0002\u00ad\u001a",
    "\u0003\u0002\u0002\u0002\u00ae\u00af\u0007G\u0002\u0002\u00af\u00b0",
    "\u0007Z\u0002\u0002\u00b0\u00b1\u0007K\u0002\u0002\u00b1\u00b2\u0007",
    "V\u0002\u0002\u00b2\u001c\u0003\u0002\u0002\u0002\u00b3\u00b4\u0007",
    "H\u0002\u0002\u00b4\u00b5\u0007K\u0002\u0002\u00b5\u00b6\u0007P\u0002",
    "\u0002\u00b6\u00b7\u0007C\u0002\u0002\u00b7\u00b8\u0007N\u0002\u0002",
    "\u00b8\u001e\u0003\u0002\u0002\u0002\u00b9\u00ba\u0007J\u0002\u0002",
    "\u00ba\u00bb\u0007Q\u0002\u0002\u00bb\u00bc\u0007W\u0002\u0002\u00bc",
    "\u00bd\u0007T\u0002\u0002\u00bd \u0003\u0002\u0002\u0002\u00be\u00bf",
    "\u0007K\u0002\u0002\u00bf\u00c0\u0007P\u0002\u0002\u00c0\u00c1\u0007",
    "E\u0002\u0002\u00c1\u00c2\u0007N\u0002\u0002\u00c2\u00c3\u0007W\u0002",
    "\u0002\u00c3\u00c4\u0007F\u0002\u0002\u00c4\u00c5\u0007G\u0002\u0002",
    "\u00c5\"\u0003\u0002\u0002\u0002\u00c6\u00c7\u0007K\u0002\u0002\u00c7",
    "\u00c8\u0007P\u0002\u0002\u00c8\u00c9\u0007K\u0002\u0002\u00c9\u00ca",
    "\u0007V\u0002\u0002\u00ca\u00cb\u0007K\u0002\u0002\u00cb\u00cc\u0007",
    "C\u0002\u0002\u00cc\u00cd\u0007N\u0002\u0002\u00cd$\u0003\u0002\u0002",
    "\u0002\u00ce\u00cf\u0007O\u0002\u0002\u00cf\u00d0\u0007C\u0002\u0002",
    "\u00d0\u00d1\u0007V\u0002\u0002\u00d1\u00d2\u0007E\u0002\u0002\u00d2",
    "\u00d3\u0007J\u0002\u0002\u00d3\u00d4\u0007K\u0002\u0002\u00d4\u00d5",
    "\u0007P\u0002\u0002\u00d5\u00d6\u0007I\u0002\u0002\u00d6&\u0003\u0002",
    "\u0002\u0002\u00d7\u00d8\u0007O\u0002\u0002\u00d8\u00d9\u0007K\u0002",
    "\u0002\u00d9\u00da\u0007P\u0002\u0002\u00da\u00db\u0007W\u0002\u0002",
    "\u00db\u00dc\u0007V\u0002\u0002\u00dc\u00dd\u0007G\u0002\u0002\u00dd",
    "(\u0003\u0002\u0002\u0002\u00de\u00df\u0007P\u0002\u0002\u00df\u00e0",
    "\u0007C\u0002\u0002\u00e0\u00e1\u0007O\u0002\u0002\u00e1\u00e2\u0007",
    "G\u0002\u0002\u00e2*\u0003\u0002\u0002\u0002\u00e3\u00e4\u0007P\u0002",
    "\u0002\u00e4\u00e5\u0007Q\u0002\u0002\u00e5,\u0003\u0002\u0002\u0002",
    "\u00e6\u00e7\u0007P\u0002\u0002\u00e7\u00e8\u0007Q\u0002\u0002\u00e8",
    "\u00e9\u0007V\u0002\u0002\u00e9.\u0003\u0002\u0002\u0002\u00ea\u00eb",
    "\u0007Q\u0002\u0002\u00eb\u00ec\u0007P\u0002\u0002\u00ec0\u0003\u0002",
    "\u0002\u0002\u00ed\u00ee\u0007Q\u0002\u0002\u00ee\u00ef\u0007T\u0002",
    "\u0002\u00ef2\u0003\u0002\u0002\u0002\u00f0\u00f1\u0007R\u0002\u0002",
    "\u00f1\u00f2\u0007C\u0002\u0002\u00f2\u00f3\u0007T\u0002\u0002\u00f3",
    "\u00f4\u0007C\u0002\u0002\u00f4\u00f5\u0007O\u0002\u0002\u00f5\u00f6",
    "\u0007G\u0002\u0002\u00f6\u00f7\u0007V\u0002\u0002\u00f7\u00f8\u0007",
    "G\u0002\u0002\u00f8\u00f9\u0007T\u0002\u0002\u00f94\u0003\u0002\u0002",
    "\u0002\u00fa\u00fb\u0007T\u0002\u0002\u00fb\u00fc\u0007W\u0002\u0002",
    "\u00fc\u00fd\u0007N\u0002\u0002\u00fd\u00fe\u0007G\u0002\u0002\u00fe",
    "6\u0003\u0002\u0002\u0002\u00ff\u0100\u0007U\u0002\u0002\u0100\u0101",
    "\u0007Y\u0002\u0002\u0101\u0102\u0007K\u0002\u0002\u0102\u0103\u0007",
    "V\u0002\u0002\u0103\u0104\u0007E\u0002\u0002\u0104\u0105\u0007J\u0002",
    "\u0002\u01058\u0003\u0002\u0002\u0002\u0106\u0107\u0007U\u0002\u0002",
    "\u0107\u0108\u0007G\u0002\u0002\u0108\u0109\u0007S\u0002\u0002\u0109",
    "\u010a\u0007W\u0002\u0002\u010a\u010b\u0007G\u0002\u0002\u010b\u010c",
    "\u0007P\u0002\u0002\u010c\u010d\u0007E\u0002\u0002\u010d\u010e\u0007",
    "G\u0002\u0002\u010e:\u0003\u0002\u0002\u0002\u010f\u0110\u0007U\u0002",
    "\u0002\u0110\u0111\u0007V\u0002\u0002\u0111\u0112\u0007C\u0002\u0002",
    "\u0112\u0113\u0007V\u0002\u0002\u0113\u0114\u0007G\u0002\u0002\u0114",
    "<\u0003\u0002\u0002\u0002\u0115\u0116\u0007V\u0002\u0002\u0116\u0117",
    "\u0007K\u0002\u0002\u0117\u0118\u0007O\u0002\u0002\u0118\u0119\u0007",
    "G\u0002\u0002\u0119>\u0003\u0002\u0002\u0002\u011a\u011b\u0007Y\u0002",
    "\u0002\u011b\u011c\u0007C\u0002\u0002\u011c\u011d\u0007K\u0002\u0002",
    "\u011d\u011e\u0007V\u0002\u0002\u011e\u011f\u0007K\u0002\u0002\u011f",
    "\u0120\u0007P\u0002\u0002\u0120\u0121\u0007I\u0002\u0002\u0121@\u0003",
    "\u0002\u0002\u0002\u0122\u0123\u0007Y\u0002\u0002\u0123\u0124\u0007",
    "K\u0002\u0002\u0124\u0125\u0007V\u0002\u0002\u0125\u0126\u0007J\u0002",
    "\u0002\u0126B\u0003\u0002\u0002\u0002\u0127\u0128\u0007Y\u0002\u0002",
    "\u0128\u0129\u0007J\u0002\u0002\u0129\u012a\u0007G\u0002\u0002\u012a",
    "\u012b\u0007P\u0002\u0002\u012bD\u0003\u0002\u0002\u0002\u012c\u0131",
    "\u0007)\u0002\u0002\u012d\u0132\n\u0002\u0002\u0002\u012e\u012f\u0007",
    ")\u0002\u0002\u012f\u0132\u0007)\u0002\u0002\u0130\u0132\u0005]/\u0002",
    "\u0131\u012d\u0003\u0002\u0002\u0002\u0131\u012e\u0003\u0002\u0002\u0002",
    "\u0131\u0130\u0003\u0002\u0002\u0002\u0132\u0133\u0003\u0002\u0002\u0002",
    "\u0133\u0131\u0003\u0002\u0002\u0002\u0133\u0134\u0003\u0002\u0002\u0002",
    "\u0134\u0135\u0003\u0002\u0002\u0002\u0135\u0136\u0007)\u0002\u0002",
    "\u0136F\u0003\u0002\u0002\u0002\u0137\u013e\u0007$\u0002\u0002\u0138",
    "\u013d\n\u0003\u0002\u0002\u0139\u013a\u0007$\u0002\u0002\u013a\u013d",
    "\u0007$\u0002\u0002\u013b\u013d\u0005]/\u0002\u013c\u0138\u0003\u0002",
    "\u0002\u0002\u013c\u0139\u0003\u0002\u0002\u0002\u013c\u013b\u0003\u0002",
    "\u0002\u0002\u013d\u0140\u0003\u0002\u0002\u0002\u013e\u013c\u0003\u0002",
    "\u0002\u0002\u013e\u013f\u0003\u0002\u0002\u0002\u013f\u0141\u0003\u0002",
    "\u0002\u0002\u0140\u013e\u0003\u0002\u0002\u0002\u0141\u0142\u0007$",
    "\u0002\u0002\u0142H\u0003\u0002\u0002\u0002\u0143\u0144\u0007*\u0002",
    "\u0002\u0144J\u0003\u0002\u0002\u0002\u0145\u0146\u0007+\u0002\u0002",
    "\u0146L\u0003\u0002\u0002\u0002\u0147\u0148\u0007=\u0002\u0002\u0148",
    "N\u0003\u0002\u0002\u0002\u0149\u014a\u0007.\u0002\u0002\u014aP\u0003",
    "\u0002\u0002\u0002\u014b\u014c\u00070\u0002\u0002\u014cR\u0003\u0002",
    "\u0002\u0002\u014d\u014f\t\u0004\u0002\u0002\u014e\u014d\u0003\u0002",
    "\u0002\u0002\u014f\u0150\u0003\u0002\u0002\u0002\u0150\u014e\u0003\u0002",
    "\u0002\u0002\u0150\u0151\u0003\u0002\u0002\u0002\u0151\u0152\u0003\u0002",
    "\u0002\u0002\u0152\u0153\b*\u0002\u0002\u0153T\u0003\u0002\u0002\u0002",
    "\u0154\u0155\t\u0005\u0002\u0002\u0155V\u0003\u0002\u0002\u0002\u0156",
    "\u0158\t\u0006\u0002\u0002\u0157\u0156\u0003\u0002\u0002\u0002\u0158",
    "\u0159\u0003\u0002\u0002\u0002\u0159\u0157\u0003\u0002\u0002\u0002\u0159",
    "\u015a\u0003\u0002\u0002\u0002\u015aX\u0003\u0002\u0002\u0002\u015b",
    "\u015c\u0007/\u0002\u0002\u015c\u015d\u0007/\u0002\u0002\u015d\u0161",
    "\u0003\u0002\u0002\u0002\u015e\u0160\n\u0007\u0002\u0002\u015f\u015e",
    "\u0003\u0002\u0002\u0002\u0160\u0163\u0003\u0002\u0002\u0002\u0161\u015f",
    "\u0003\u0002\u0002\u0002\u0161\u0162\u0003\u0002\u0002\u0002\u0162\u0166",
    "\u0003\u0002\u0002\u0002\u0163\u0161\u0003\u0002\u0002\u0002\u0164\u0167",
    "\u0005]/\u0002\u0165\u0167\u0007\u0002\u0002\u0003\u0166\u0164\u0003",
    "\u0002\u0002\u0002\u0166\u0165\u0003\u0002\u0002\u0002\u0167\u0168\u0003",
    "\u0002\u0002\u0002\u0168\u0169\b-\u0003\u0002\u0169Z\u0003\u0002\u0002",
    "\u0002\u016a\u016b\u00071\u0002\u0002\u016b\u016c\u0007,\u0002\u0002",
    "\u016c\u0170\u0003\u0002\u0002\u0002\u016d\u016f\u000b\u0002\u0002\u0002",
    "\u016e\u016d\u0003\u0002\u0002\u0002\u016f\u0172\u0003\u0002\u0002\u0002",
    "\u0170\u0171\u0003\u0002\u0002\u0002\u0170\u016e\u0003\u0002\u0002\u0002",
    "\u0171\u0173\u0003\u0002\u0002\u0002\u0172\u0170\u0003\u0002\u0002\u0002",
    "\u0173\u0174\u0007,\u0002\u0002\u0174\u0175\u00071\u0002\u0002\u0175",
    "\u0176\u0003\u0002\u0002\u0002\u0176\u0177\b.\u0003\u0002\u0177\\\u0003",
    "\u0002\u0002\u0002\u0178\u017a\u0007\u000f\u0002\u0002\u0179\u0178\u0003",
    "\u0002\u0002\u0002\u0179\u017a\u0003\u0002\u0002\u0002\u017a\u017b\u0003",
    "\u0002\u0002\u0002\u017b\u017c\u0007\f\u0002\u0002\u017c^\u0003\u0002",
    "\u0002\u0002\u017d\u017e\t\b\u0002\u0002\u017e`\u0003\u0002\u0002\u0002",
    "\u017f\u0184\u0005U+\u0002\u0180\u0183\u0005U+\u0002\u0181\u0183\t\t",
    "\u0002\u0002\u0182\u0180\u0003\u0002\u0002\u0002\u0182\u0181\u0003\u0002",
    "\u0002\u0002\u0183\u0186\u0003\u0002\u0002\u0002\u0184\u0182\u0003\u0002",
    "\u0002\u0002\u0184\u0185\u0003\u0002\u0002\u0002\u0185b\u0003\u0002",
    "\u0002\u0002\u0186\u0184\u0003\u0002\u0002\u0002\u000f\u0002\u0131\u0133",
    "\u013c\u013e\u0150\u0159\u0161\u0166\u0170\u0179\u0182\u0184\u0004\b",
    "\u0002\u0002\u0002\u0003\u0002"].join("");


var atn = new antlr4.atn.ATNDeserializer().deserialize(serializedATN);

var decisionsToDFA = atn.decisionToState.map( function(ds, index) { return new antlr4.dfa.DFA(ds, index); });

function WorkflowLexer(input) {
	antlr4.Lexer.call(this, input);
    this._interp = new antlr4.atn.LexerATNSimulator(this, atn, decisionsToDFA, new antlr4.PredictionContextCache());
    return this;
}

WorkflowLexer.prototype = Object.create(antlr4.Lexer.prototype);
WorkflowLexer.prototype.constructor = WorkflowLexer;

WorkflowLexer.EOF = antlr4.Token.EOF;
WorkflowLexer.ACTION = 1;
WorkflowLexer.AFTER = 2;
WorkflowLexer.AND = 3;
WorkflowLexer.BEFORE = 4;
WorkflowLexer.CONST = 5;
WorkflowLexer.DESCRIPTION = 6;
WorkflowLexer.DAY = 7;
WorkflowLexer.DEFINE = 8;
WorkflowLexer.EVENT = 9;
WorkflowLexer.EXECUTE = 10;
WorkflowLexer.ENTER = 11;
WorkflowLexer.EQUAL = 12;
WorkflowLexer.EXIT = 13;
WorkflowLexer.FINAL = 14;
WorkflowLexer.HOUR = 15;
WorkflowLexer.INCLUDE = 16;
WorkflowLexer.INITIAL = 17;
WorkflowLexer.MATCHING = 18;
WorkflowLexer.MINUTE = 19;
WorkflowLexer.NAME = 20;
WorkflowLexer.NO = 21;
WorkflowLexer.NOT = 22;
WorkflowLexer.ON = 23;
WorkflowLexer.OR = 24;
WorkflowLexer.PARAMETER = 25;
WorkflowLexer.RULE = 26;
WorkflowLexer.SWITCH = 27;
WorkflowLexer.SEQUENCE = 28;
WorkflowLexer.STATE = 29;
WorkflowLexer.TIME = 30;
WorkflowLexer.WAITING = 31;
WorkflowLexer.WITH = 32;
WorkflowLexer.WHEN = 33;
WorkflowLexer.CHAR_STRING = 34;
WorkflowLexer.CHAR_COMMENT = 35;
WorkflowLexer.LEFT_PAREN = 36;
WorkflowLexer.RIGHT_PAREN = 37;
WorkflowLexer.SEMICOLON = 38;
WorkflowLexer.COMMA = 39;
WorkflowLexer.DOT = 40;
WorkflowLexer.SPACES = 41;
WorkflowLexer.NUMBER = 42;
WorkflowLexer.SINGLE_LINE_COMMENT = 43;
WorkflowLexer.MULTI_LINE_COMMENT = 44;
WorkflowLexer.REGULAR_ID = 45;

WorkflowLexer.prototype.channelNames = [ "DEFAULT_TOKEN_CHANNEL", "HIDDEN" ];

WorkflowLexer.prototype.modeNames = [ "DEFAULT_MODE" ];

WorkflowLexer.prototype.literalNames = [ null, "'ACTION'", "'AFTER'", "'AND'", 
                                         "'BEFORE'", "'CONST'", "'DESCRIPTION'", 
                                         "'DAY'", "'DEFINE'", "'EVENT'", 
                                         "'EXECUTE'", "'ENTER'", "'='", 
                                         "'EXIT'", "'FINAL'", "'HOUR'", 
                                         "'INCLUDE'", "'INITIAL'", "'MATCHING'", 
                                         "'MINUTE'", "'NAME'", "'NO'", "'NOT'", 
                                         "'ON'", "'OR'", "'PARAMETER'", 
                                         "'RULE'", "'SWITCH'", "'SEQUENCE'", 
                                         "'STATE'", "'TIME'", "'WAITING'", 
                                         "'WITH'", "'WHEN'", null, null, 
                                         "'('", "')'", "';'", "','", "'.'" ];

WorkflowLexer.prototype.symbolicNames = [ null, "ACTION", "AFTER", "AND", 
                                          "BEFORE", "CONST", "DESCRIPTION", 
                                          "DAY", "DEFINE", "EVENT", "EXECUTE", 
                                          "ENTER", "EQUAL", "EXIT", "FINAL", 
                                          "HOUR", "INCLUDE", "INITIAL", 
                                          "MATCHING", "MINUTE", "NAME", 
                                          "NO", "NOT", "ON", "OR", "PARAMETER", 
                                          "RULE", "SWITCH", "SEQUENCE", 
                                          "STATE", "TIME", "WAITING", "WITH", 
                                          "WHEN", "CHAR_STRING", "CHAR_COMMENT", 
                                          "LEFT_PAREN", "RIGHT_PAREN", "SEMICOLON", 
                                          "COMMA", "DOT", "SPACES", "NUMBER", 
                                          "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
                                          "REGULAR_ID" ];

WorkflowLexer.prototype.ruleNames = [ "ACTION", "AFTER", "AND", "BEFORE", 
                                      "CONST", "DESCRIPTION", "DAY", "DEFINE", 
                                      "EVENT", "EXECUTE", "ENTER", "EQUAL", 
                                      "EXIT", "FINAL", "HOUR", "INCLUDE", 
                                      "INITIAL", "MATCHING", "MINUTE", "NAME", 
                                      "NO", "NOT", "ON", "OR", "PARAMETER", 
                                      "RULE", "SWITCH", "SEQUENCE", "STATE", 
                                      "TIME", "WAITING", "WITH", "WHEN", 
                                      "CHAR_STRING", "CHAR_COMMENT", "LEFT_PAREN", 
                                      "RIGHT_PAREN", "SEMICOLON", "COMMA", 
                                      "DOT", "SPACES", "SIMPLE_LETTER", 
                                      "NUMBER", "SINGLE_LINE_COMMENT", "MULTI_LINE_COMMENT", 
                                      "NEWLINE", "SPACE", "REGULAR_ID" ];

WorkflowLexer.prototype.grammarFileName = "WorkflowLexer.g4";



exports.WorkflowLexer = WorkflowLexer;

