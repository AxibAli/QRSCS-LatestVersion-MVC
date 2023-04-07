using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QRSCS.Models;
using System.Data.Entity;

namespace QRSCS.Manager
{
    public class SpeechCaseHistoryManager
    {
        New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();

        int speechCaseID = 0;
        public int AddSpeechCaseHistory(SpeachCaseHistoryModelDTO grno)
        {
            using (New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities())
            {
                Speach_Case_History table = new Speach_Case_History();
                table.GR_NO = grno.SpeechCaseHistory.GR_NO;
                db.Speach_Case_History.Add(table);
                speechCaseID = table.Speach_Case_History_ID;

                General_Information table2 = new General_Information();
                table2.Speach_Case_History_ID = grno.SpeechCaseHistory.Speach_Case_History_ID;
                table2.Today_Date = grno.GeneralInformation.Today_Date;
                table2.Child_Primary_Language = grno.GeneralInformation.Child_Primary_Language;
                table2.Parent_Primary_Language = grno.GeneralInformation.Parent_Primary_Language;
                table2.Live_With_Both_Parents = grno.GeneralInformation.Live_With_Both_Parents;
                table2.Child_Primary_Caregiver = grno.GeneralInformation.Child_Primary_Caregiver;
                table2.Child_Primary_Caregiver_Language = grno.GeneralInformation.Child_Primary_Caregiver_Language;
                db.General_Information.Add(table2);

                Speach_and_Langauge table3 = new Speach_and_Langauge();
                table3.Speach_Case_History_ID = grno.SpeechCaseHistory.Speach_Case_History_ID;
                table3.Speech_Text = grno.SpeechAndLanguage.Speech_Text;
                db.Speach_and_Langauge.Add(table3);

                Receptive_langauge table4 = new Receptive_langauge();
                table4.Speach_Case_History_ID = grno.SpeechCaseHistory.Speach_Case_History_ID;
                table4.Single_Words = grno.ReceptiveLangauge.Single_Words;
                table4.Yes_No_Questions = grno.ReceptiveLangauge.Yes_No_Questions;
                table4.Sentences = grno.ReceptiveLangauge.Sentences;
                table4.WH_Questions = grno.ReceptiveLangauge.WH_Questions;
                table4.Routine_Questions = grno.ReceptiveLangauge.Routine_Questions;
                table4.Conversation_Text = grno.ReceptiveLangauge.Conversation_Text;
                db.Receptive_langauge.Add(table4);

                Expressive_Langauage table5 = new Expressive_Langauage();
                table5.Speach_Case_History_ID = grno.SpeechCaseHistory.Speach_Case_History_ID;
                table5.Babble = grno.ExpressiveLangauage.Babble;
                table5.First_Word = grno.ExpressiveLangauage.First_Word;
                table5.Combine_2_Word = grno.ExpressiveLangauage.Combine_2_Word;
                table5.Complete_Sentence = grno.ExpressiveLangauage.Complete_Sentence;
                table5.Gestures = grno.ExpressiveLangauage.Gestures;
                table5.Phrases = grno.ExpressiveLangauage.Phrases;
                table5.Sing_Language = grno.ExpressiveLangauage.Sing_Language;
                table5.Sentence = grno.ExpressiveLangauage.Sentence;
                table5.Words = grno.ExpressiveLangauage.Words;
                table5.Conversation_Ex_Text = grno.ExpressiveLangauage.Conversation_Ex_Text;
                table5.When_Did_Concerned_Child_Speech = grno.ExpressiveLangauage.When_Did_Concerned_Child_Speech;
                table5.Caused_Your_Child_Difficulty = grno.ExpressiveLangauage.Caused_Your_Child_Difficulty;
                table5.Worse_Better_Overtime = grno.ExpressiveLangauage.Worse_Better_Overtime;
                table5.Self_Consious_Speech_Langauge = grno.ExpressiveLangauage.Self_Consious_Speech_Langauge;
                table5.Speech_Language_Hearing_Family = grno.ExpressiveLangauage.Speech_Language_Hearing_Family;
                table5.Professionals_Seen_Child = grno.ExpressiveLangauage.Professionals_Seen_Child;
                db.Expressive_Langauage.Add(table5);

                Developmental_History table6 = new Developmental_History();
                table6.Speach_Case_History_ID = grno.SpeechCaseHistory.Speach_Case_History_ID;
                table6.Use_Single_Word = grno.DevelopmentalHistory.Use_Single_Word;
                table6.Combine_Word = grno.DevelopmentalHistory.Combine_Word;
                table6.Name_Single_Object = grno.DevelopmentalHistory.Name_Single_Object;
                table6.Use_Simple_Sentence = grno.DevelopmentalHistory.Use_Simple_Sentence;
                table6.Engage_Conversation = grno.DevelopmentalHistory.Engage_Conversation;
                table6.Consistently_Sound = grno.DevelopmentalHistory.Consistently_Sound;
                table6.Difficulty_Hearing_Speech = grno.DevelopmentalHistory.Difficulty_Hearing_Speech;
                table6.HearingTest_Where_When = grno.DevelopmentalHistory.HearingTest_Where_When;
                table6.Diificult_Understand_Speech = grno.DevelopmentalHistory.Diificult_Understand_Speech;
                table6.SpecificSounds_Incoorectly = grno.DevelopmentalHistory.SpecificSounds_Incoorectly;
                table6.Difficulty_Understanding_Direction = grno.DevelopmentalHistory.Difficulty_Understanding_Direction;
                table6.Difficulty_PlayActivities = grno.DevelopmentalHistory.Difficulty_PlayActivities;
                table6.Engage_Excussive_Repetition_Word = grno.DevelopmentalHistory.Engage_Excussive_Repetition_Word;
                table6.Feeding_Problem = grno.DevelopmentalHistory.Feeding_Problem;
                db.Developmental_History.Add(table6);

                db.SaveChanges();
                speechCaseID = table.Speach_Case_History_ID;
            }
            return speechCaseID;

        }
    }
}