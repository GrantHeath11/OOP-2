open System

// Define constants for the range of the random number
// let is the keyword to define things in F#
let lowNumber = 1
let highNumber = 50

// Function to play the game
let playGame () =
    // Generate a random number
    let random = Random()
    let correctNumber = random.Next(lowNumber, highNumber + 1)

    // Loops game
    let rec gameLoop () =
        printf $"Guess the number (between {lowNumber} and {highNumber}): "
        let input = Console.ReadLine()
        // exception handling
        match Int32.TryParse(input) with
        | (true, guess) when guess = correctNumber ->
            printfn "Congratulations! You guessed the number %d correctly!" correctNumber
        | (true, guess) when guess < correctNumber ->
            printfn "Too low! Try again."
            gameLoop() // Lets user reguess after guessing too low
        | (true, guess) when guess > correctNumber ->
            printfn "Too high! Try again."
            gameLoop() // lets user reguess after guessing too high
        | _ ->  // this line is for any other unexpected condition
            printfn "Invalid input. Please enter a valid number."
            gameLoop() // Re prompts user to try to enter a number again

    gameLoop() // Start the game loop

// Function to ask if the user wants to play again
let rec askPlayAgain () =
    printf "Do you want to play again? (yes/no): "
    let response = Console.ReadLine().ToLower()

    match response with
    | "yes" -> 
        Console.Clear();//  Clears console
        true // Continue playing
    | "no" ->
        Console.Clear();//  Clears console
        printfn "Thanks for playing!" 
        false // Exit the loopa
    | _ ->
        printfn "Invalid input. Please enter 'yes' or 'no'."
        askPlayAgain() // Repeat the question

// Entry point of the application
[<EntryPoint>]
let main argv =
    printfn "Welcome to the Guess the Number Game!"
    
    let mutable keepPlaying = true // Flag to control the loop
    while keepPlaying do
        playGame() // Start the game
        keepPlaying <- askPlayAgain() // Update flag based on user input

    0 // Return exit code
