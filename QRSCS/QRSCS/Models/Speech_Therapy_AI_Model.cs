using Microsoft.Ajax.Utilities;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace QRSCS.Models
{
    public class Speech_Therapy_AI_Model
    {
        public bool exec_model(string  name,int uid)
        {
            var context = new MLContext();
            var data = context.Data.LoadFromTextFile<Speech_Therapy_Input_Model>(AppDomain.CurrentDomain.BaseDirectory + @"Content\CSV_for_AI_Model\" + name + " speech therapy assessment.csv",
                hasHeader: false, separatorChar: ',');
            Debug.WriteLine(data.ToString()+"--------------");
            var pipeline = context.Forecasting.ForecastBySsa(
                nameof(Speech_Therapy_Forecast.Forecast),
                nameof(Speech_Therapy_Input_Model.Marks),
                windowSize: 4,
                seriesLength: 10,
                trainSize: 100,
                horizon: 1);

            var model = pipeline.Fit(data);

            var forecastingEngine = model.CreateTimeSeriesEngine<Speech_Therapy_Input_Model, Speech_Therapy_Forecast>(context);

            var forecasts = forecastingEngine.Predict();
            Debug.WriteLine(forecasts.Forecast);
            foreach (var forecast in forecasts.Forecast)
            {
                Debug.WriteLine(forecast);
            }
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Content\CSV_for_AI_Model\" + name + " speech therapy assessment.csv";

            try
            {
                    if (System.IO.File.Exists(fileName))
                    {
                        System.IO.File.Delete(fileName);
                    }
                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                    New_QRSCS_DatabaseEntities db = new New_QRSCS_DatabaseEntities();
                        var request = db.Speech_Therapy_Assessment.Where(x => x.GR_NO == uid).Select(x => x.Marks).ToList(); 
                        var request1 = db.Speech_Therapy_Assessment.Where(x => x.GR_NO == uid).Select(x => x.Date).ToList();
                    StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < request.Count; i++)
                        {
                            sb.Append(request1[i] + "," + request[i] + ",");
                            sb.Append("\r\n");

                        }
                        foreach (var forecast in forecasts.Forecast)
                        {
                            sb.Append(DateTime.Now + "," + forecast + ",");
                            sb.Append("\r\n");

                        }

                        byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());
                        fs.Write(bytes, 0, bytes.Length);
                    return true;
                    }


                }
                catch (Exception Ex)
                {
                    Console.WriteLine(Ex.ToString());
                }
            return false;
        }



        
    }
}