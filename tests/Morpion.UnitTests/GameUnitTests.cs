using Morpion.BoardGame;
using System;
using Xunit;

namespace Morpion.UnitTests
{
    public class GameUnitTests
    {
        Game game = new Game();

        [Fact(DisplayName = "When the game is initialized, the grid should only contain empty values")]
        public void When_Game_Is_Initialized_Grid_Should_Contain_Only_Empty_Row()
        {
            // Act
            game = new Game();
            
            // Assert
            for (int i=0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.Equal(0, game.Grid[i, j]);
                }
            }
        }

        [InlineData(0, 0, GridEnumValue.O)]
        [InlineData(0, 1, GridEnumValue.X)]
        [InlineData(2, 2, GridEnumValue.X)]
        [InlineData(2, 1, GridEnumValue.O)]
        [Theory(DisplayName = "When the player is playing the place value should be set")]
        public void When_Player_Play_At_Position_Value_Should_Be_Setted(int x, int y, GridEnumValue value)
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(x, y, value);

            // Assert
            Assert.Equal((int)value, game.Grid[x, y]);
        }

        [Fact(DisplayName = "When the player is playing at the position already played must throw an PositionAlreadyPlayedException")]
        public void When_Player_Play_At_Already_Played_Position_Should_Throw_PositionAlreadyPlayerException()
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(0, 0, GridEnumValue.X);
            Action action = () => game.SetValue(0, 0, GridEnumValue.X);

            // Assert
            Assert.Throws<PositionAlreadyPlayedException>(action);
        }

        [Fact(DisplayName = "When the player has play at three not aligned different position, he should not win")]
        public void When__Player_Play_At_Three__Not_Aligned_Different_Position_Should_Not_Win()
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(0, 0, GridEnumValue.X);
            game.SetValue(0, 1, GridEnumValue.X);
            game.SetValue(1, 2, GridEnumValue.X);

            // Assert
            Assert.False(game.Won(GridEnumValue.X));
        }

        [Fact(DisplayName = "When the player set the horizontal line should win")]
        public void When_Player_Set_Horizontal_Line_Should_Win()
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(0, 0, GridEnumValue.X);
            game.SetValue(0, 1, GridEnumValue.X);
            game.SetValue(0, 2, GridEnumValue.X);

            // Assert
            Assert.True(game.Won(GridEnumValue.X));
        }

        [Fact(DisplayName = "When the player set the vertical line should win")]
        public void When_Player_Set_Vertical_Line_Should_Win()
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(0, 0, GridEnumValue.O);
            game.SetValue(1, 0, GridEnumValue.O);
            game.SetValue(2, 0, GridEnumValue.O);

            // Assert
            Assert.True(game.Won(GridEnumValue.O));
        }

        [Fact(DisplayName = "When the player set the diagonal line should win")]
        public void When_Player_Set_Diagonal_Line_Should_Win()
        {
            // Arrange
            game = new Game();

            // Act
            game.SetValue(0, 0, GridEnumValue.O);
            game.SetValue(1, 1, GridEnumValue.O);
            game.SetValue(2, 2, GridEnumValue.O);

            // Assert
            Assert.True(game.Won(GridEnumValue.O));
        }

        [Fact(DisplayName = "When game is over with no winner should return equality")]
        public void When_Game_Is_Over_With_No_Winner_Should_Return_Equality()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(false, "Please complete the unit test");
        }

        [Fact(DisplayName = "Bonus : Draw the game")]
        public void When_Draw_The_Game_Should_Return_Grid()
        {
            // Arrange

            // Act

            // Assert
            Assert.True(false, "Please complete the unit test");
        }
    }
}
