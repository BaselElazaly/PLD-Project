﻿
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                  =  0, // (EOF)
        SYMBOL_ERROR                =  1, // (Error)
        SYMBOL_WHITESPACE           =  2, // Whitespace
        SYMBOL_MINUS                =  3, // '-'
        SYMBOL_MINUSMINUS           =  4, // '--'
        SYMBOL_EXCLAMEQ             =  5, // '!='
        SYMBOL_PERCENT              =  6, // '%'
        SYMBOL_LPAREN               =  7, // '('
        SYMBOL_RPAREN               =  8, // ')'
        SYMBOL_TIMES                =  9, // '*'
        SYMBOL_TIMESTIMES           = 10, // '**'
        SYMBOL_DIV                  = 11, // '/'
        SYMBOL_COLON                = 12, // ':'
        SYMBOL_SEMI                 = 13, // ';'
        SYMBOL_LBRACE               = 14, // '{'
        SYMBOL_RBRACE               = 15, // '}'
        SYMBOL_PLUS                 = 16, // '+'
        SYMBOL_PLUSPLUS             = 17, // '++'
        SYMBOL_LT                   = 18, // '<'
        SYMBOL_EQ                   = 19, // '='
        SYMBOL_EQEQ                 = 20, // '=='
        SYMBOL_GT                   = 21, // '>'
        SYMBOL_CASE                 = 22, // case
        SYMBOL_CASES                = 23, // Cases
        SYMBOL_CHOOSE               = 24, // Choose
        SYMBOL_DEFAULT              = 25, // default
        SYMBOL_DIGIT                = 26, // Digit
        SYMBOL_DO                   = 27, // do
        SYMBOL_DOUBLE               = 28, // double
        SYMBOL_ELSE                 = 29, // else
        SYMBOL_END                  = 30, // End
        SYMBOL_FLOAT                = 31, // float
        SYMBOL_FOR                  = 32, // For
        SYMBOL_ID                   = 33, // Id
        SYMBOL_IF                   = 34, // if
        SYMBOL_INT                  = 35, // int
        SYMBOL_SO                   = 36, // so
        SYMBOL_START                = 37, // Start
        SYMBOL_STRING               = 38, // string
        SYMBOL_WHILE                = 39, // while
        SYMBOL_ASSIGN               = 40, // <assign>
        SYMBOL_CONCEPT              = 41, // <concept>
        SYMBOL_COND                 = 42, // <cond>
        SYMBOL_DATA                 = 43, // <data>
        SYMBOL_DEFAULTMINUSGAME     = 44, // <default-Game>
        SYMBOL_DIGIT2               = 45, // <digit>
        SYMBOL_DO_WHILE_STMT        = 46, // <do_while_stmt>
        SYMBOL_EXP                  = 47, // <exp>
        SYMBOL_EXPR                 = 48, // <expr>
        SYMBOL_FACTOR               = 49, // <factor>
        SYMBOL_FOR_STMT             = 50, // <for_stmt>
        SYMBOL_GAME                 = 51, // <Game>
        SYMBOL_GAMES                = 52, // <Games>
        SYMBOL_ID2                  = 53, // <id>
        SYMBOL_IF_STMT              = 54, // <if_stmt>
        SYMBOL_OP                   = 55, // <op>
        SYMBOL_PROGRAM              = 56, // <program>
        SYMBOL_STEP                 = 57, // <step>
        SYMBOL_STMT_LIST            = 58, // <stmt_list>
        SYMBOL_SWITCHMINUSSTATEMENT = 59, // <switch-statement>
        SYMBOL_TERM                 = 60, // <term>
        SYMBOL_WHILEMINUSSTATEMENT  = 61  // <while-statement>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                       =  0, // <program> ::= Start <stmt_list> End
        RULE_STMT_LIST                                               =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                              =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                                 =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                                =  4, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                                =  5, // <concept> ::= <switch-statement>
        RULE_CONCEPT4                                                =  6, // <concept> ::= <for_stmt>
        RULE_CONCEPT5                                                =  7, // <concept> ::= <while-statement>
        RULE_CONCEPT6                                                =  8, // <concept> ::= <do_while_stmt>
        RULE_ASSIGN_EQ_SEMI                                          =  9, // <assign> ::= <id> '=' <expr> ';'
        RULE_ID_ID                                                   = 10, // <id> ::= Id
        RULE_EXPR_PLUS                                               = 11, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                              = 12, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                    = 13, // <expr> ::= <term>
        RULE_TERM_TIMES                                              = 14, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                = 15, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                            = 16, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                    = 17, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                       = 18, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                                  = 19, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                       = 20, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                     = 21, // <exp> ::= <id>
        RULE_EXP2                                                    = 22, // <exp> ::= <digit>
        RULE_DIGIT_DIGI                                              = 23, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPAREN_RPAREN_SO                             = 24, // <if_stmt> ::= if '(' <cond> ')' so <stmt_list>
        RULE_IF_STMT_IF_LPAREN_RPAREN_SO_ELSE                        = 25, // <if_stmt> ::= if '(' <cond> ')' so <stmt_list> else <stmt_list>
        RULE_COND                                                    = 26, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                                   = 27, // <op> ::= '<'
        RULE_OP_GT                                                   = 28, // <op> ::= '>'
        RULE_OP_EQEQ                                                 = 29, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                             = 30, // <op> ::= '!='
        RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE      = 31, // <for_stmt> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
        RULE_DATA_INT                                                = 32, // <data> ::= int
        RULE_DATA_FLOAT                                              = 33, // <data> ::= float
        RULE_DATA_DOUBLE                                             = 34, // <data> ::= double
        RULE_DATA_STRING                                             = 35, // <data> ::= string
        RULE_STEP_MINUSMINUS                                         = 36, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                        = 37, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                           = 38, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                          = 39, // <step> ::= <id> '++'
        RULE_STEP                                                    = 40, // <step> ::= <assign>
        RULE_SWITCHSTATEMENT_CHOOSE_LPAREN_RPAREN_CASES_END          = 41, // <switch-statement> ::= Choose '(' <cond> ')' Cases <Games> End
        RULE_GAMES                                                   = 42, // <Games> ::= <Game>
        RULE_GAMES2                                                  = 43, // <Games> ::= <Game> <Games>
        RULE_GAMES3                                                  = 44, // <Games> ::= <default-Game>
        RULE_GAME_CASE_COLON                                         = 45, // <Game> ::= case <id> ':' <stmt_list>
        RULE_DEFAULTGAME_DEFAULT_COLON                               = 46, // <default-Game> ::= default ':' <stmt_list>
        RULE_WHILESTATEMENT_WHILE_LPAREN_RPAREN_START_END            = 47, // <while-statement> ::= while '(' <cond> ')' Start <stmt_list> End
        RULE_DO_WHILE_STMT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI = 48  // <do_while_stmt> ::= do '{' <stmt_list> '}' while '(' <cond> ')' ';'
    };

    public class MyParser
    {
        private LALRParser parser;
         ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst, ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(ReadTokenEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASES :
                //Cases
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHOOSE :
                //Choose
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //For
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SO :
                //so
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DATA :
                //<data>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULTMINUSGAME :
                //<default-Game>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STMT :
                //<do_while_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GAME :
                //<Game>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GAMES :
                //<Games>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHMINUSSTATEMENT :
                //<switch-statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILEMINUSSTATEMENT :
                //<while-statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <switch-statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <while-statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <do_while_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <id> '=' <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGI:
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_SO :
                //<if_stmt> ::= if '(' <cond> ')' so <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_SO_ELSE :
                //<if_stmt> ::= if '(' <cond> ')' so <stmt_list> else <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stmt> ::= For '(' <data> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_INT :
                //<data> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_FLOAT :
                //<data> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_DOUBLE :
                //<data> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DATA_STRING :
                //<data> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_CHOOSE_LPAREN_RPAREN_CASES_END :
                //<switch-statement> ::= Choose '(' <cond> ')' Cases <Games> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GAMES :
                //<Games> ::= <Game>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GAMES2 :
                //<Games> ::= <Game> <Games>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GAMES3 :
                //<Games> ::= <default-Game>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_GAME_CASE_COLON :
                //<Game> ::= case <id> ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULTGAME_DEFAULT_COLON :
                //<default-Game> ::= default ':' <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILESTATEMENT_WHILE_LPAREN_RPAREN_START_END :
                //<while-statement> ::= while '(' <cond> ')' Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STMT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI :
                //<do_while_stmt> ::= do '{' <stmt_list> '}' while '(' <cond> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'"+ "  in line "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 ="Expected token: "+args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

        private void ReadTokenEvent(LALRParser pr, TokenReadEventArgs args )
        {
            string info = args.Token.Text + "   \t \t " + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
