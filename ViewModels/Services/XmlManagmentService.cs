﻿using ImageFiltersWPF.ViewModels.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Xml.Serialization;

namespace ImageFiltersWPF.ViewModels.Services
{
    /// <summary>
    /// Class responsible for serializing adn deserializing files
    /// </summary>
    public class XmlManagmentService : IXmlManagmentService
    {
        private readonly ILogger<XmlManagmentService> logger;

        public XmlManagmentService(ILogger<XmlManagmentService> logger)
        {
            this.logger = logger;
        }

        public bool XmlDeserialize<T>(string sourcePath, out T deserializedObject)
        {
            logger.LogInformation($"XmlDeserialize() of type {typeof(T)} || Path: {sourcePath}");
            var streamReader = File.OpenRead(sourcePath);
            var deserializer = new XmlSerializer(typeof(T));
            try
            {
                deserializedObject = (T)deserializer.Deserialize(streamReader);
                return true;
            }
            catch (Exception ex)
            {
                deserializedObject = default(T);
                logger.LogError($"XmlDeserialize() of type {typeof(T)} || Path: {sourcePath} || {ex.Message}");
                return false;
            }
            finally
            {
                streamReader.Flush();
                streamReader.Close();
                streamReader.Dispose();
            }
        }

        public bool XmlSerialize<T>(T objectToSerialize, string destinationPath)
        {
            logger.LogInformation($"XmlSerialize() of type {typeof(T)} || Path: {destinationPath}");

            var serializer = new XmlSerializer(typeof(T));
            var streamWriter = new StreamWriter(destinationPath, true);

            try
            {
                serializer.Serialize(streamWriter, objectToSerialize);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"XmlSerialize() of type {typeof(T)} || Path: {destinationPath} || {ex.Message}");
                return false;
            }
            finally
            {
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}