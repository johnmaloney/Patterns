using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patterns;
using Patterns.Recursion;
using PatternsTests;

namespace PatternsTests
{
    [TestClass]
    public class RecursionTests
    {
        [TestMethod]
        public void create_hanoi_tower_expect_rules()
        {

            //       =1           =       =
            //      =2=           =       =
            //     ==3==          =       = 
            //    ===4===         =       =
            //   ====5====        =       =
            //=================================

            var amountOfDisks = 8;

            var tower = new HanoiTower();

            var source = new Stack<int>().AddRange(amountOfDisks);
            var destination = new Stack<int>();
            var temporary = new Stack<int>();

            tower.MoveTower(source.Count, source, destination, temporary);

            Assert.AreEqual(0, source.Count);
            Assert.AreEqual(amountOfDisks, destination.Count);
            Assert.AreEqual(0, temporary.Count);
        }

        [TestMethod]
        public void permute_text_expect_all_variations()
        {
            var permuter = new Permutations();
            permuter.PermuteText("", "john");

            var specificResult = permuter.Results.FirstOrDefault(s => s == "nhoj");
            Assert.AreEqual("nhoj", specificResult);
        }

        [TestMethod]
        public void find_subset_expect_matches()
        {
            var subSetter = new Permutations();
            subSetter.SubsetText("", "abcd");

            var specificResult = subSetter.Results.FirstOrDefault(s => s == "j");
        }

        [TestMethod]
        [DeploymentItem("Dictionary/dictionary.json", "/")]
        public void discover_if_set_of_text_can_be_word()
        {
            var backTracker = new WordBackTracker();
            Assert.IsTrue(backTracker.IsAnagram("", "estt"));
        }

        [TestMethod]
        public void test_is_safe_check_expect_proper_results()
        {
            var chessBoard = new ChessBoard(8, 8);
            chessBoard.PlaceQueen(1, 1);

            // Test Left moving check //
            var isSafe = chessBoard.IsSafe(4, 1);
            Assert.IsFalse(isSafe);
            chessBoard.ClearBoard();

            // Test right moving check
            chessBoard.PlaceQueen(6, 4);
            isSafe = chessBoard.IsSafe(0, 4);
            Assert.IsFalse(isSafe);
            chessBoard.ClearBoard();

            // Test Moving diagonal Upper Left//
            chessBoard.PlaceQueen(2, 2);
            isSafe = chessBoard.IsSafe(4, 4);
            Assert.IsFalse(isSafe);
            chessBoard.ClearBoard();

            // Test Moving diagonal Upper Right //
            chessBoard.PlaceQueen(6, 2);
            isSafe = chessBoard.IsSafe(3, 5);
            Assert.IsFalse(isSafe);
            chessBoard.ClearBoard();

        }

        [TestMethod]
        public void place_queens_on_the_board_expect_safety_foreach_queen()
        {
            var chessBoard = new ChessBoard(8, 8);
            Assert.AreEqual(8, chessBoard.Rows);
            Assert.AreEqual(8, chessBoard.Columns);

            var player = new EightQueens(chessBoard);
            player.Solve(0);
        } 
    }

   
}
