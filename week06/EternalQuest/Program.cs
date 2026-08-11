/*
=================================================================================
EXCEEDING ENHANCEMENTS:
1. Gamification System (Leveling & Ranks):
   - Implemented a dynamic level system based on earned points (1000 points per level).
   - Added custom title ranks based on player progress (Novice Adventurer, Apprentice Guardian, etc.).
   - Integrated a visual progress bar in the main menu to show progress toward the next level.

2. Robust File Persistence & CSV Extension Enforcement:
   - Built automatic filename sanitization (`EnsureCsvExtension`) to guarantee `.csv` extensions, 
   clean extra spaces/quotes, and set default fallbacks.
   - Handled non-existent files: 
   if a user attempts to load a missing file, the program offers to initialize a new valid CSV file 
   using the exact user-provided filename without redundant re-prompts.

3. Input Validation & Exit Handling:
   - Implemented a robust `PromptForInt` helper method to catch non-numeric inputs and prevent crashes.
   - Added cancellation support ('q' / 'Q') across prompt workflows to allow 
   smooth navigation back to the main menu without throwing errors.
=================================================================================
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}