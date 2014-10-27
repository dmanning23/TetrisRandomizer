using System;
using System.Collections.Generic;

namespace TetrisRandomizer
{
	/// <summary>
	/// This class uses the TGM Randomizer to generate random game peices.
	/// This is for when you want instead of pure random numbers, a psuedo-random that doesnt repeat as often.
	/// </summary>
	class RandomBag
	{
		#region Properties

		/// <summary>
		///linked list of the last four peices that were put into play
		/// </summary>
		public Queue<int> ShapeHistory { get; set; }

        /// <summary>
        /// The max num that will be returned.
        /// all numbers will be between 0 -> maxnum
        /// </summary>
        public int MaxNum { get; set; }

        /// <summary>
        /// The size of the random bag. Bigger bag is less random.
        /// Defaults to 4, which is a good size if you want random numbers between 0-6
        /// </summary>
        public int BagSize { get; set; }

        /// <summary>
        /// The number of times it will retry to get a number that isn't already in the bag before giving up.
        /// Defaults to 4, which is a good size if you want random numbers between 0-6
        /// </summary>
        public int RandomTries { get; set;}

		/// <summary>
		/// A random generator.
		/// </summary>
		static private readonly Random _random = new Random();

		#endregion //Properties

		#region Initialization / Cleanup

		/// <summary>
		/// constructor
		/// </summary>
		/// <param name="maxNum"></param>
		/// <param name="bagSize"></param>
		/// <param name="randomTries"></param>
        public RandomBag(int maxNum, int bagSize = 4, int randomTries = 4)
		{
            MaxNum = maxNum;
            BagSize = bagSize;
            RandomTries = randomTries;
		}

		#endregion //Initialization / Cleanup

		#region Methods

		/// <summary>
		/// Create a random shape.
		/// </summary>
		/// <returns>Tetrad: a pseduo-random tetrad, generated using TGM algorithm</returns>
		public int Next()
		{
			//variable used to store the random piece we come up with.
            int randomShape = 0;

			//try to get a crispy peice 6 times, then give up
			int i = 0;
            while (i < RandomTries)
			{
				//get a random piece
                randomShape = _random.Next(MaxNum);

				//Check if that peice has been played recently
				bool bFound = false;
				foreach (int num in ShapeHistory)
				{
                    if (num == randomShape)
					{
						//crap this peice has been played recently
						bFound = true;
						break;
					}
				}

				//Is this peice ok, or did we find it in the recent history?
				if (bFound)
				{
					i++;
				}
				else
				{
					//if it gets here, we found a random piece that wasn't in the history.
					break;
				}
			}

			//okay, got a new peice, add it to the end of the list and pop off the front
            AddShapeToHistory(randomShape);

			// Return the new shape.
            return randomShape;
		}

		/// <summary>
		/// Adds the shape to history.
		/// </summary>
		/// <param name="shapeType">Shape type to put in history</param>
		private void AddShapeToHistory(int shapeType)
		{
			ShapeHistory.Dequeue();
			ShapeHistory.Enqueue(shapeType);

			//verify the size of the history queue
            while (ShapeHistory.Count > BagSize)
			{
				ShapeHistory.Dequeue();
			}
		}

		#endregion //Methods
	}
}
