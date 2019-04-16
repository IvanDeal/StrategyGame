using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGame
{
    class PlayerCharacter
    {
        /* Core choices for Player to make */
        string sPlayerCharacterName;
        string sPlayerCharacterRace;
        string sPlayerCharacterSize;
        string sPlayerCharacterHairColour; /*Should be an int if we use hex codes? */
        string sPlayerCharacterEyeColour;
        string sPlayerCharacterClass;
        string sPlayerCharacterAlignment;

        int iPlayerCharacterHeight;
        int iPlayerCharacterWeight;
        int iPlayerCharacterAge;
        int iPlayerCharacterLevel;
        int iPlayerCharacterExperienceTotal;
        int iPlayerCharacterProficiencyBonus;
        int iPlayerCharacterArmourClass;
        int iPlayerCharacterInitiative;
        int iPlayerCharacterGroundSpeed;
        int iPlayerCharacterFlySeed;
        int iPlayerCharacterHitPoints;
        int iPlayerCharacterHitDie; /* This is the value used when levelling up to determine HP */
        int iPlayerCharacterHitDice; /* This is how many dice are available to use for healing during a short rest */ 

        /* Primary attributes */
        int iPlayerCharacterStrength; //Base Stat
        int iPlayerCharacterConstitution; //Base Stat
        int iPlayerCharacterDexterity; // Base Stat
        int iPlayerCharacterIntelligence; // Base Stat
        int iPlayerCharacterWisdom; // Base Stat
        int iPlayerCharacterCharisma; // Base Stat

        /* Bonuses derived from primary attributes */
        int iPlayerCharacterStrengthBonus; // 
        int iPlayerCharacterConstitutionBonus;
        int iPlayerCharacterDexterityBonus;
        int iPlayerCharacterIntelligenceBonus;
        int iPlayerCharacterWisdomBonus;
        int iPlayerCharacterCharismaBonus;

        /* Derived attributes */
        int iPlayerCharacterStrengthSave;
        int iPlayerCharacterConstitutionSave;
        int iPlayerCharacterDexteritySave;
        int iPlayerCharacterIntelligenceSave;
        int iPlayerCharacterWisdomSave;
        int iPlayerCharacterCharismaSave;
        int iPlayerCharacterPassivePerception;

        /* Player Damage resistances */
        public bool bPlayerCharacterAcidResistance = false;
        public bool bPlayerCharacterBludgeoningResistance = false;
        public bool bPlayerCharacterColdResistance = false;
        public bool bPlayerCharacterFireResistance = false;
        public bool bPlayerCharacterForceResistance = false;
        public bool bPlayerCharacterLightningResistance = false;
        public bool bPlayerCharacterNecroticResistance = false;
        public bool bPlayerCharacterPiercingResistance = false;
        public bool bPlayerCharacterPoisonResistance = false;
        public bool bPlayerCharacterPsychicResistance = false;
        public bool bPlayerCharacterRadiantResistance = false;
        public bool bPlayerCharacterSlashingResistance = false;
        public bool bPlayerCharacterThunderResistance = false;

        /* Player damage immunities */
        public bool bPlayerCharacterAcidImmunity = false;
        public bool bPlayerCharacterBludgeoningImmunity = false;
        public bool bPlayerCharacterColdImmunity = false;
        public bool bPlayerCharacterFireImmunity = false;
        public bool bPlayerCharacterForceImmunity = false;
        public bool bPlayerCharacterLightningImmunity = false;
        public bool bPlayerCharacterNecroticImmunity = false;
        public bool bPlayerCharacterPiercingImmunity = false;
        public bool bPlayerCharacterPoisonImmunity = false;
        public bool bPlayerCharacterPsychicImmunity = false;
        public bool bPlayerCharacterRadiantImmunity = false;
        public bool bPlayerCharacterSlashingImmunity = false;
        public bool bPlayerCharacterThunderImmunity = false;

        /* Player damage vulnerabilities */
        public bool bPlayerCharacterAcidVulneerability = false;
        public bool bPlayerCharacterBludgeoningVulnerability = false;
        public bool bPlayerCharacterColdVulnerability = false;
        public bool bPlayerCharacterFireVulnerability = false;
        public bool bPlayerCharacterForceVulnerability = false;
        public bool bPlayerCharacterLightningVulnerability = false;
        public bool bPlayerCharacterNecroticVulnerability = false;
        public bool bPlayerCharacterPiercingVulnerability = false;
        public bool bPlayerCharacterPoisonVulnerability = false;
        public bool bPlayerCharacterPsychicVulnerability = false;
        public bool bPlayerCharacterRadiantVulnerability = false;
        public bool bPlayerCharacterSlashingVulnerability = false;
        public bool bPlayerCharacterThunderVulnerability = false;

        /* Player status immunities */
        public bool bPlayerCharacterBlindedImmunity = false;
        public bool bPlayerCharacterCharmedImmunity = false;
        public bool bPlayerCharacterDeafenedImmunity = false;
        public bool bPlayerCharacterExhaustionImmunity = false;
        public bool bPlayerCharacterFrightenedImmunity = false;
        public bool bPlayerCharacterGrappledImmunity = false;
        public bool bPlayerCharacterIncapacitatedImmunity = false;
        public bool bPlayerCharacterInvisibleImmunity = false;
        public bool bPlayerCharacterParalyzedImmunity = false;
        public bool bPlayerCharacterPetrifiedImmunity = false;
        public bool bPlayerCharacterPoisonedImmunity = false;
        public bool bPlayerCharacterProneImmunity = false;
        public bool bPlayerCharacterRestrainedImmunity = false;
        public bool bPlayerCharacterStunnedImmunity = false;
        public bool bPlayerCharacterUnconsciousImmunity = false;

        /* Player languages */
        public bool bPlayerCharacterKnowsCommon = false;
        public bool bPlayerCharacterKnowsDwarvish = false;
        public bool bPlayerCharacterKnowsElvish = false;
        public bool bPlayerCharacterKnowsGiant = false;
        public bool bPlayerCharacterKnowsGnomish = false;
        public bool bPlayerCharacterKnowsGoblin = false;
        public bool bPlayerCharacterKnowsHalfling = false;
        public bool bPlayerCharacterKnowsOrc = false;
        public bool bPlayerCharacterKnowsAbyssal = false;
        public bool bPlayerCharacterKnowsCelestial = false;
        public bool bPlayerCharacterKnowsDraconic = false;
        public bool bPlayerCharacterKnowsDeepSpeech = false;
        public bool bPlayerCharacterKnowsInfernal = false;
        public bool bPlayerCharacterKnowsPrimordial = false;
        public bool bPlayerCharacterKnowsSlyvan = false;
        public bool bPlayerCharacterKnowsundercommon = false;


        public PlayerCharacter()
        {
            PlayerRace chosenRace = new PlayerRace();
            PlayerCharacterClass chosenCharacterClass = new PlayerCharacterClass();
            SetPlayerSavingThrows();

        }

        /* Rolling a D6 four times, taking away the lowest number and adding the remaining three to create a total */
        public int CalculatePlayerBaseStats()
        {
           Random rnd = new Random();
            int[] diceResultArray = new int[4];
            
            for (int i = 0; i < diceResultArray.Length; i++)
            {
                int diceRoll = rnd.Next(1, 7);
                diceResultArray[i] = diceRoll;
                Console.WriteLine("The dice roll result is " + diceRoll);
            }

            int diceTotal = diceResultArray[0] + diceResultArray[1] + diceResultArray[2] + diceResultArray[3];
            int lowestNumber = 0;

            foreach (int diceResult in diceResultArray)
            {
                int currentLowest = 6;
                if (diceResult < currentLowest)
                {
                    currentLowest = diceResult;
                }
                lowestNumber = currentLowest;
            }

            diceTotal = diceTotal - lowestNumber;
            Console.WriteLine("Total is " + diceTotal);
            Console.ReadLine();

            return diceTotal;
        }

        public void SetPlayerBaseStats()
        {
            iPlayerCharacterStrength = CalculatePlayerBaseStats();
            iPlayerCharacterConstitution = CalculatePlayerBaseStats();
            iPlayerCharacterDexterity = CalculatePlayerBaseStats();
            iPlayerCharacterWisdom = CalculatePlayerBaseStats();
            iPlayerCharacterIntelligence = CalculatePlayerBaseStats();
            iPlayerCharacterCharisma = CalculatePlayerBaseStats();  
        }

        public void SetPlayerStatBonuses()
        {
            GetPlayerStatBonuses(iPlayerCharacterStrength);
            GetPlayerStatBonuses(iPlayerCharacterConstitution);
            GetPlayerStatBonuses(iPlayerCharacterDexterity);
            GetPlayerStatBonuses(iPlayerCharacterWisdom);
            GetPlayerStatBonuses(iPlayerCharacterIntelligence);
            GetPlayerStatBonuses(iPlayerCharacterCharisma);
        }

        public int GetPlayerStatBonuses(int primaryStat)
        {
            int bonus = 0;
            switch (primaryStat)
            {
                case 1:
                    bonus = -5;
                    break;
                case 2:
                case 3:
                    bonus = -4;
                    break;
                case 4:
                case 5:
                    bonus = -3;
                    break;
                case 6:
                case 7:
                    bonus = -2;
                    break;
                case 8:
                case 9:
                    bonus = -1;
                    break;
                case 10:
                case 11:
                    bonus = 0;
                    break;
                case 12:
                case 13:
                    bonus = 1;
                    break;
                case 14:
                case 15:
                    bonus = 2;
                    break;
                case 16:
                case 17:
                    bonus = 3;
                    break;
                case 18:
                case 19:
                    bonus = 4;
                    break;
                case 20:
                case 21:
                    bonus = 5;
                    break;
                case 22:
                case 23:
                    bonus = 6;
                    break;
                case 24:
                case 25:
                    bonus = 7;
                    break;
                case 26:
                case 27:
                    bonus = 8;
                    break;
                case 28:
                case 29:
                    bonus = 9;
                    break;
                case 30:
                    bonus = 10;
                    break;
            }

            return bonus;
        }

        public void SetPlayerSavingThrows()
        {
            if (sPlayerCharacterClass == "Barbarian" )
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;

            }
            else if (sPlayerCharacterClass == "Bard")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus + iPlayerCharacterProficiencyBonus;
            }
            else if (sPlayerCharacterClass == "Cleric")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;

            }
            else if (sPlayerCharacterClass == "Druid")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
            else if (sPlayerCharacterClass == "Fighter")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
            else if (sPlayerCharacterClass == "Monk")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
            else if (sPlayerCharacterClass == "Paladin")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus + iPlayerCharacterProficiencyBonus;
            }
            else if (sPlayerCharacterClass == "Ranger")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
            else if (sPlayerCharacterClass == "Rogue")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
            else if (sPlayerCharacterClass == "Sorcerer")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus + iPlayerCharacterProficiencyBonus;
            }
            else if (sPlayerCharacterClass == "Warlock")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus + iPlayerCharacterProficiencyBonus;
            }
            else if (sPlayerCharacterClass == "Wizard")
            {
                iPlayerCharacterStrengthSave = iPlayerCharacterStrengthBonus;
                iPlayerCharacterConstitutionSave = iPlayerCharacterConstitutionBonus;
                iPlayerCharacterDexteritySave = iPlayerCharacterDexterityBonus;
                iPlayerCharacterIntelligenceSave = iPlayerCharacterIntelligenceBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterWisdomSave = iPlayerCharacterWisdomBonus + iPlayerCharacterProficiencyBonus;
                iPlayerCharacterCharismaSave = iPlayerCharacterCharismaBonus;
            }
        }

        public void SetPlayerSecondaryStats()
        {

        }

        public void SetPlayerConditionImmunities()
        {
        bPlayerCharacterBlindedImmunity = false;
        bPlayerCharacterCharmedImmunity = false;
        bPlayerCharacterDeafenedImmunity = false;
        bPlayerCharacterExhaustionImmunity = false;
        bPlayerCharacterFrightenedImmunity = false;
        bPlayerCharacterGrappledImmunity = false;
        bPlayerCharacterIncapacitatedImmunity = false;
        bPlayerCharacterInvisibleImmunity = false;
        bPlayerCharacterParalyzedImmunity = false;
        bPlayerCharacterPetrifiedImmunity = false;
        bPlayerCharacterPoisonedImmunity = false;
        bPlayerCharacterProneImmunity = false;
        bPlayerCharacterRestrainedImmunity = false;
        bPlayerCharacterStunnedImmunity = false;
        bPlayerCharacterUnconsciousImmunity = false;

        }

        public void SetPlayerDamageResistances()
        {

        bPlayerCharacterAcidResistance = false;
        bPlayerCharacterBludgeoningResistance = false;
        bPlayerCharacterColdResistance = false;
        bPlayerCharacterFireResistance = false;
        bPlayerCharacterForceResistance = false;
        bPlayerCharacterLightningResistance = false;
        bPlayerCharacterNecroticResistance = false;
        bPlayerCharacterPiercingResistance = false;
        bPlayerCharacterPoisonResistance = false;
        bPlayerCharacterPsychicResistance = false;
        bPlayerCharacterRadiantResistance = false;
        bPlayerCharacterSlashingResistance = false;
        bPlayerCharacterThunderResistance = false;

        }

        public void SetPlayerDamageImmunites()
        {
            bPlayerCharacterAcidImmunity = false;
            bPlayerCharacterBludgeoningImmunity = false;
            bPlayerCharacterColdImmunity = false;
            bPlayerCharacterFireImmunity = false;
            bPlayerCharacterForceImmunity = false;
            bPlayerCharacterLightningImmunity = false;
            bPlayerCharacterNecroticImmunity = false;
            bPlayerCharacterPiercingImmunity = false;
            bPlayerCharacterPoisonImmunity = false;
            bPlayerCharacterPsychicImmunity = false;
            bPlayerCharacterRadiantImmunity = false;
            bPlayerCharacterSlashingImmunity = false;
            bPlayerCharacterThunderImmunity = false;
        }

        public void SetPlayerLanguages()
        {

        }

    }
}
