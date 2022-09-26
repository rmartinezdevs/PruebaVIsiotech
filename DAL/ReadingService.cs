using PruebaNivel.Models;
using System;
using System.Collections.Generic;
using Visiotech.HardwareInfo;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace PruebaNivel.DAL
{
    public class ReadingService : IReadingService
    {
        public List<Measure> GetMeasures()
        {
            var measures = new List<Measure>();
            const string FileName = @"SavedMeasures.bin";

            if (File.Exists(FileName))
            {
                openFile(FileName, measures);
            }
            else
            {
                PerformanceCounter cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";

                PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                for (int i = 1; i <= 2; i++)
                {
                    measures.Add(new Measure()
                    {
                        ID = i,
                        LastDate = DateTime.Now.AddDays(i),
                        CPUSerial = HardwareInfo.GetProcessor(),
                        MotherboardSerial = HardwareInfo.GetMotherboard(),
                        CPUusage = cpuCounter.NextValue(),
                        RAMusage = ramCounter.NextValue()
                    });

                    saveFile(FileName, measures);
                    
                }
            }
        return measures;
        }
        public void saveFile(string FileName, List<Measure> measures)
        {
            Stream SaveFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(SaveFileStream, measures);
            SaveFileStream.Close();
        }

        public void openFile(string FileName, List<Measure> measures)
        {
            Console.WriteLine("Reading saved file");
            Stream openFileStream = File.OpenRead(FileName);
            BinaryFormatter deserializer = new BinaryFormatter();
            measures = (List<Measure>)deserializer.Deserialize(openFileStream);
            openFileStream.Close();
        }
    }
}
