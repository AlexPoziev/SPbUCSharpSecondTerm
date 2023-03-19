using Tree;

var checkParseTree = new ParseTree("(+ (+ 1 2) (/ 3 1))");

var test = checkParseTree.Calculate();

var testik = 0;

checkParseTree.Print();