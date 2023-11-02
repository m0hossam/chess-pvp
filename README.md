# Player-vs-Player Chess

A simple Chess Engine that allows you to play Chess against your friends on the same computer.

## Table Of Contents

- [Chess Engine Features](https://github.com/m0hossam/chess-pvp#chess-engine-features)
- [Project Specifications](https://github.com/m0hossam/chess-pvp#project-specifications)
- [What I Learned](https://github.com/m0hossam/chess-pvp#what-i-learned)
- [How To Install & Run](https://github.com/m0hossam/chess-pvp#how-to-install--run)
- [Credits](https://github.com/m0hossam/chess-pvp#credits)

# Chess Engine Features

The Engine supports the following features:
- All standard Chess moves
- All special Chess moves:
  - Castling
  - Promotion
  - En Passant
- Game state evaluation:
  - Check
  - Checkmate
  - Stalemate
  
You can select the type of piece you want to promote to using the combo-box at the right of the board.
You can begin a new game using the New Game button on the right of the board.

## Gameplay Screenshots:

![New game started!](https://user-images.githubusercontent.com/115721045/209452901-5732f3a2-3645-4ad7-9a2a-c3dbf1848428.png)
![Scholar's mate, white won by checkmate!](https://user-images.githubusercontent.com/115721045/209452923-e8088921-a2fd-4463-96e3-3cfe4360f83a.png)
![Stafford gambit, black won by checkmate!](https://user-images.githubusercontent.com/115721045/209452938-8f4ed2e3-8e48-4b75-838f-db738a446fcb.png)

# Project Specifications

The project was done in .NET Framework 4.5.2 using the Windows Presentation Foundation (WPF) Application template.
The architectural pattern followed was the Model-View-ViewModel (MVVM) pattern, where the solution has 2 projects, one UI project that contains the XAML files, and one Engine project that contains the Models and ViewModels.

## Unit Testing

To test the validity of the engine's move generation, I used a [Perft](https://www.chessprogramming.org/Perft) function and compared my engine's results up to **Depth 4** with the standard [Perft results](https://www.chessprogramming.org/Perft_Results).
Testing further than **Depth 4** could not be done easily right now due to the inefficieny of the engine, but could be implemented in a future update.

### Screenshot:

![Perft test passed!](https://user-images.githubusercontent.com/115721045/209452962-8462407c-2b33-4ad6-88e0-062dc928f104.png)

## *Disclaimer*:

I uptook this project only to practice OOP fundamentals, the implementation of the engine is inefficient in comparison to conventional Chess engines' implementations.
For efficient Chess engine implementations, check out [Chessprogramming wiki](https://www.chessprogramming.org/Main_Page).

# What I Learned

- OOP Fundamentals:
  - Abstraction
  - Encapsulation
  - Inheritance
  - Polymorphism
- MVVM Architectural Pattern
- Unit Testing Basics
- C# & WPF Basics
- Chess Engines

# How To Play

- Open the [Releases](https://github.com/m0hossam/chess-pvp/releases/) page
- Download **Chess.rar** from the Assets of the latest release
- Extract **Chess.rar**
- Grab a friend
- Open **Chess.exe**
- Enjoy :)

# Credits

- [Scott's Open-Source C# Role-Playing Game](https://soscsrpg.com/)
  - For MVVM, WPF and unit testing basics.
- [Chessprogramming wiki](https://www.chessprogramming.org/Main_Page)
  - For Engine details.
- [Cburnett](https://commons.wikimedia.org/wiki/File:Chess_Pieces_Sprite.svg)
  - For pieces design.
- [Lichess](https://lichess.org/)
  - For board color scheme and audio.
- [Stack Overflow](https://stackoverflow.com/)
  - For debugging.
