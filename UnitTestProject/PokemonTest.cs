﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonUnity;
using PokemonUnity.Pokemon;
using PokemonUnity.Move;
using PokemonUnity.Item;

namespace Tests
{
    [TestClass]
    public class PokemonTest
	{
		//Create 2 assert test; 1 for regular pokemon, and one for pokemon.NONE
		//Pokemon.NONE cannot receive any changes to data, as it does not exist...

		#region HP/Status...
		[TestMethod]
        public void Pokemon_SetHP_To_Zero()
        {
            Pokemon pokemon = new Pokemon();
            pokemon.HP = 0;
            Assert.AreEqual(0, pokemon.HP);
        }

        [TestMethod]//[ExpectedException(typeof(Exception))]
        public void Pokemon_SetHP_GreaterThan_MaxHP_Equals_MaxHP() 
        {
            Pokemon pokemon = new Pokemon();
            pokemon.HP = pokemon.TotalHP + 1;
            /*try
            {
                pokemon.HP = pokemon.TotalHP + 1;
                Assert.Fail();
            }
            catch (Exception e)
            {
                //Assert.AreEqual(error, pokemon.HP);
                Assert.IsTrue(e is Exception);
            }*/
            Assert.AreEqual(pokemon.TotalHP, pokemon.HP);
        }

        [TestMethod]
        public void Pokemon_SetStatus_To_Burn() {
            Pokemon pokemon = new Pokemon();
            pokemon.Status = Status.Burn;
            Assert.AreEqual(Status.Burn, pokemon.Status);
			//Assert.Inconclusive();
		}

        [TestMethod]
        public void Pokemon_Sleep_StatusTurn_Not_Zero() {
            Pokemon pokemon = new Pokemon();
            pokemon.Status = Status.Sleep;
			//If remaining turns for sleep is 0 then the pokemon would be awake.
            Assert.AreNotEqual(0, pokemon.statusCount);
		}

        [TestMethod]
        public void Pokemon_FullyHeal() 
        {
            Pokemon pokemon = new Pokemon();
            pokemon.HP = 0;
            pokemon.HealHP();
            Assert.AreEqual(pokemon.TotalHP, pokemon.HP);
        }

        [TestMethod]
        public void Pokemon_MakeFainted() 
        {
            Pokemon pokemon = new Pokemon();
            pokemon.HP = 0;
            Assert.IsTrue(pokemon.isFainted());
        }

        [TestMethod]
        public void Pokemon_SetPokerus_To_Infected()
        {
            Pokemon pokemon = new Pokemon();
            pokemon.GivePokerus();
            Assert.IsTrue(pokemon.PokerusStage.Value);
        }
        #endregion

        #region Level/stats...
        [TestMethod]
		public void Pokemon_Set_ExperiencePoints_To_Match_Level()
		{
			Assert.Inconclusive();
		}
		
        [TestMethod]
		public void Pokemon_Set_Level_To_Match_ExperiencePoints()
		{
			Pokemon pokemon = new Pokemon(Pokemons.BULBASAUR);
			//pokemon.exp = pokemon.TotalHP + 1;
			Assert.Inconclusive();
		}

		//Test max value for pokemon stats
        [TestMethod]
		public void Pokemon_EV_GreaterThan_MaxEV_Equals_MaxEV()
		{
			Pokemon pokemon = new Pokemon();
			Assert.AreEqual(Pokemon.EVSTATLIMIT, pokemon.EV[0]);
		}

        [TestMethod]
		public void Pokemon_CombinedEV_Fail_GreaterThan_EV_MaxLimit()
		{
			//All EV points when added together cannot be greater than a sum of MaxEVLimit
			Pokemon pokemon = new Pokemon();
			int ev = pokemon.EV[0] + pokemon.EV[1] + pokemon.EV[2] + pokemon.EV[3] + pokemon.EV[4] + pokemon.EV[5];
			Assert.AreEqual(Pokemon.EVLIMIT, ev);
		}
        #endregion

        #region Moves...
        [TestMethod]
		public void Pokemon_TeachMove_Add_NewMove()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		/// <summary>
		/// Move list should be full OR not compatible with pokemon
		/// </summary>
		public void Pokemon_Full_Moves_Fail_TeachMove()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		/// <summary>
		/// Remove random move, packs the move list, and confirm move is missing
		/// </summary>
		public void Pokemon_ForgetMove_Minus_Move()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		/// <summary>
		/// 
		/// </summary>
		/// ToDo: Resetting pokemon moves should randomly shuffle between all available that pokemon can possibly learn for their level
		public void Pokemon_ResetMoves_NotEqual_DefaultMoves()
		{
			Assert.Inconclusive();
		}
		[TestMethod]
		public void Pokemon_Replace_Move_Return_Different_Moves()
		{
			Assert.Inconclusive();
		}
		[TestMethod]
		public void Pokemon_Swap_Moves_Change_OrderOf_Moves()
		{
			Assert.Inconclusive();
		}
		[TestMethod]
		public void Pokemon_Return_MoveList_CanLearn_At_CurrentLevel()
		{
			//list of moves can learn at level
			Assert.Inconclusive();
		}
		[TestMethod]
		public void Pokemon_PokemonTest_CantLearn_Move_NotCompatible_With_Pokemon()
		{
			//list of moves can learn at level
			Assert.Inconclusive();
		}
		[TestMethod]
		public void Pokemon_PokemonTest_CantLearn_Move_NotCompatible_With_TeachMethod()
		{
			//list of moves can learn at level
			Assert.Inconclusive();
		}
        #endregion

        #region Misc
        [TestMethod]
        public void Pokemon_TestPokemon_SetForm_To_Form2()
        {
            Pokemon pokemon = new Pokemon(Pokemons.NONE);
            pokemon.Form = 2;
            Assert.AreEqual("test1", pokemon.Name);
        }
        [TestMethod]
		//Changing form changes base stats
        public void Pokemon_TestPokemon_SetForm_IncreasesAtkStats()
        {
            Pokemon pokemon = new Pokemon(Pokemons.NONE);
            pokemon.Form = 1;
			//Assert.AreNotEqual(Pokemon.PokemonData.GetPokemon(pokemon.Species).BaseStatsATK, pokemon.ATK);
			Assert.Fail("Need to find way to compare Pokemon.baseStats to Form.baseStats");
        }
        [TestMethod]
		public void Pokemon_TestPokemon_GetPokemon_From_Form()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Set_Ribbons_Tier3_OutOf_4()
		{
			Pokemon pokemon = new Pokemon(Pokemons.NONE);
			//Set ribbons to tier 3
			//Check if contains other tiers rank 1 and 2
			Assert.IsTrue(pokemon.Ribbons.Contains(Ribbon.HOENNTOUGHHYPER));
			//Create 2nd assert for regular pokemon
			Assert.Fail("Pokemon NONE cannot obtain ribbons");
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Add_Ribbons_OfSameType_Increases_RankTier()
		{
			Pokemon pokemon = new Pokemon(Pokemons.NONE);
			//Add Ribbon.HOENNTOUGH x4
			Assert.IsTrue(pokemon.Ribbons.Contains(Ribbon.HOENNTOUGHHYPER));
			//Create 2nd assert for regular pokemon
			Assert.Fail("Pokemon NONE cannot obtain ribbons");
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Set_Markings()
		{
			Pokemon pokemon = new Pokemon(Pokemons.NONE)
			{
				Markings=new bool[] {false, true, true, false, false, false }
			};
			//bool[] marks = new bool[6]; marks[1] = marks[2] = true;
			Assert.IsTrue(pokemon.Markings[2]);
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Set_To_Egg()
		{
			Pokemon pokemon = new Pokemon(Pokemons.NONE);
			//If not egg
			if (pokemon.isEgg) Assert.Fail();
			//else fail
			//Set to egg

			//Assert if egg
			Assert.Inconclusive();
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Hatch_Egg()
		{
			//Set to egg
			Pokemon pokemon = new Pokemon(Pokemons.BULBASAUR)
			{
				//eggSteps = 5;
			};
			//If not egg fail
			if (!pokemon.isEgg) Assert.Fail();
			//for loop until egg hatches
			//Assert if egg
			Assert.Inconclusive();
			//When egg hatches, values need to be set:
			//pkmn.eggsteps = 0
			//pkmn.hatchedMap = 0
			//pkmn.obtainMode = 0
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Set_To_Shadow()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		public void Pokemon_TestPokemon_Shadow_Fail_To_Purify_If_HeartGuage_Not_Zero()
		{
			Assert.Inconclusive();
		}
        [TestMethod]
		public void Pokemon_TestPokemon_CanEvolve()
		{
			Pokemon pokemon = new Pokemon(Pokemons.BULBASAUR);
			//Add exp
			//Assert is true
			Assert.Inconclusive();
		}
        [TestMethod]
		public void Pokemon_TestPokemon_EvolvePokemon()
		{
			Assert.Inconclusive();
		}
        #endregion

        #region
        [TestMethod]
		public void Pokemon_Mail_Test_Pokemon_HoldMessage()
		{
			Assert.Inconclusive();
		}

        [TestMethod]
		public void Pokemon_GenderRatio_To_Gender()
		{
			//Convert GenderRatio to Male/Female Results
			Assert.Inconclusive();
		}
		#endregion
	}
}