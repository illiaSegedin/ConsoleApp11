using PRTelegramBot.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRTelegramExample.Models
{
    /// <summary>
    /// Кастомные заголовки команд
    /// </summary>
    [InlineCommand]
    public enum CustomTHeader
    {
        ExampleOne = 100, ExampleTwo, ExampleThree, ExampleFour, ExampleFive, ExampleSix, ExampleSeven, ExampleEight, ExampleNine, ExampleTen,
        CustomPage,
        ExampleOne1, ExampleTwo1, ExampleThree1, ExampleFour1, ExampleFive1,
        ExampleTwo2,
        ExampleOne3, ExampleTwo3, ExampleThree3, ExampleFour3, ExampleFive3, ExampleSix3, ExampleSeven3, ExampleEight3,
        ExampleOne4, ExampleTwo4, ExampleThree4, ExampleFour4, ExampleFive4, ExampleSix4, ExampleSeven4, ExampleEight4, ExampleNine4, ExampleTen4, ExampleEleven4, ExampleTwelve4, ExampleThirteen4,
        ExampleOne5, ExampleTwo5, ExampleThree5, ExampleFour5, ExampleFive5, ExampleSix5, ExampleSeven5, ExampleEight5, ExampleNine5, ExampleTen5, ExampleEleven5, ExampleTwelve5, ExampleThirteen5, ExampleFourteen5,
        ExampleOne6, ExampleTwo6, ExampleThree6, ExampleFour6, ExampleFive6, ExampleSix6, ExampleSeven6, ExampleEight6, ExampleNine6, ExampleTen6, ExampleEleven6, ExampleTwelve6,
        ExampleOne7, ExampleTwo7, ExampleThree7, ExampleFour7, ExampleFive7,
        ExampleOne9, ExampleTwo9, ExampleThree9, ExampleFour9, ExampleFive9, ExampleSix9, ExampleSeven9, ExampleEight9, ExampleNine9, ExampleTen9, ExampleEleven9, ExampleTwelve9, ExampleThirteen9, ExampleFourteen9, ExampleFifteen9, ExampleSixteen9, ExampleSeventeen9, ExampleEighteen9, ExampleNineteen9, ExampleTwenty9, ExampleTwentyOne9, ExampleTwentyTwo9, ExampleTwentyThree9, ExampleTwentyFour9, ExampleTwentyFive9, ExampleTwentySix9, ExampleTwentySeven9, ExampleTwentyEight9, ExampleTwentyNine9, ExampleThirty9, ExampleThirtyOne9, ExampleThirtyTwo9, ExampleThirtyThree9, ExampleThirtyFour9, ExampleThirtyFive9,
        ExampleOne10, ExampleTwo10, ExampleThree10, ExampleFour10, ExampleFive10, ExampleSix10,

        TestOne, TestTwo, TestThree,
        Back, Back1, Back2, Back3, Back4, Back5, Back6, Back7, Back9, Back10,
        Favorite
    }
}