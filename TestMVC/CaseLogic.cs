using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVC
{
    public class CaseLogic
    {
        const int BUFFER_SIZE = 8040 * 128;   //1,029,120 bytes = approx. 1Mb - buffer size should be a multiple of 8040
                                              //const int BUFFER_SIZE = 150000;   //1,029,120 bytes = approx. 1Mb - buffer size should be a multiple of 8040 - USE TO TEST FILE CHUNK
        const string DOCUMENT_STORE_FILE_SYSTEM = "CL-LFS";
        const string DOCUMENT_STORE_SQL_DATABASE = "CL-SQL";
        const int DOCUMENT_DIRECTORY_SIZE = 500;



        static public Result<bool> SaveFiles(IEnumerable<CaseFileBo> files)
        {
            Result<bool> result = new Result<bool>();

            foreach (CaseFileBo file in files)
            {
                switch ("CL-LFS")
                {
                    case DOCUMENT_STORE_FILE_SYSTEM:
                        result = SaveFileToFileSystem(file, @"D:\UploadedDocs", 1, "CR");
                        break;

                }


            }


            return result;
        }

        static Result<bool> SaveFileToFileSystem(CaseFileBo file, string CorrespondenceRootDirectory, int MatterId, string CaseModuleCode)
        {
            Result<bool> result = new Result<bool>();
            string Folder = CorrespondenceFolderPath(CorrespondenceRootDirectory, MatterId, CaseModuleCode);
            string FilePath = Path.Combine(Folder, file.FinalFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(Folder));

            File.WriteAllBytes(FilePath, file.FileData);

            result.IsSuccess = true;

            return result;
        }

        //static Result<bool> SaveFileToDatabase(EPortalDbContext context, ICaseRepository caseRepository, CaseFileBo CaseFile)
        //{
        //    Result<bool> result = new Result<bool>();

        //    ChunkFile(context,caseRepository,CaseFile);

        //    result.IsSuccess = true;

        //    return result;
        //}
        //static public bool ChunkFile(EPortalDbContext context, ICaseRepository caseRepository, CaseFileBo CaseFile)
        //{
        //    bool rslt = false;
        //    int Start = 0;
        //    //long Length;
        //    MemoryStream FS = new MemoryStream(CaseFile.FileData);
        //    // set the size of file chunk we are going to split into  150000
        //    int BufferChunkSize = BUFFER_SIZE;
        //    // set a buffer size and an array to store the buffer data as we read it  
        //    const int READBUFFER_SIZE = BUFFER_SIZE;
        //    byte[] FSBuffer = new byte[READBUFFER_SIZE];

        //        int TotalFileParts = 0;
        //        if (FS.Length < BufferChunkSize)
        //        {
        //            TotalFileParts = 1;
        //        // write to the database here just once
        //        caseRepository.WriteFileChunk(context, CaseFile.Id, FS.ToArray(),Start);
        //        FS.Dispose();
        //        return rslt;

        //    }
        //        else
        //        {
        //            float PreciseFileParts = ((float)FS.Length / (float)BufferChunkSize);
        //            TotalFileParts = (int)Math.Ceiling(PreciseFileParts);
        //        }

        //        int FilePartCount = 0;
        //        // scan through the file, and each time we get enough data to fill a chunk, write out that file  
        //        while (FS.Position < FS.Length)
        //        {

        //                int bytesRemaining = BufferChunkSize;
        //                int bytesRead = 0;
        //                while (bytesRemaining > 0 && (bytesRead = FS.Read(FSBuffer, 0,
        //                 Math.Min(bytesRemaining, READBUFFER_SIZE))) > 0)
        //                {

        //            caseRepository.WriteFileChunk(context, CaseFile.Id, FSBuffer.ToArray(), Start);
        //            //Length = FS.Length;


        //            bytesRemaining -= bytesRead;

        //            if(bytesRemaining==0)
        //            {
        //                Start += BUFFER_SIZE;
        //            }
        //            else
        //            {
        //                Start += bytesRemaining;
        //            }

        //                }

        //            FilePartCount++;
        //        }

        //    FS.Dispose();
        //    return rslt;
        //}

        //public static byte[] ReadFully(Stream stream)
        //{
        //    byte[] buffer = new byte[32768]; //set the size of your buffer (chunk)
        //    using (MemoryStream ms = new MemoryStream()) //You need a db connection instead
        //    {
        //        while (true) //loop to the end of the file
        //        {
        //            int read = stream.Read(buffer, 0, buffer.Length + buffer.Length); //read each chunk
        //            if (read <= 0) //check for end of file
        //                return ms.ToArray();
        //            ms.Write(buffer, 0, read); //write chunk to [wherever]
        //        }
        //    }
        //}



        static string CorrespondenceFolderPath(string CorrespondenceRootDirectory, int MatterId, string CaseModuleCode)
        {
            string FilePath;
            string Floor;
            string Ceiling;

            // Construct the folder block for the matter id
            Floor = (((MatterId / DOCUMENT_DIRECTORY_SIZE) * DOCUMENT_DIRECTORY_SIZE) + 1).ToString("000000");
            Ceiling = (((MatterId / DOCUMENT_DIRECTORY_SIZE) + 1) * DOCUMENT_DIRECTORY_SIZE).ToString("000000");

            // Construct the full path to the correspondence folder for the case
            FilePath = CorrespondenceRootDirectory + @"\Case\" + CaseModuleCode.Trim() + @"\" + Floor + "-" + Ceiling + @"\" + MatterId.ToString("000000") + @"\";

            return FilePath;
        }

        static public Result<CaseFileBo> GetFile(int FileId, string UserName)
        {
            Result<CaseFileBo> result = new Result<CaseFileBo>();
            CaseFileBo CaseFile = null;
            CaseFileBo FileDetails = new CaseFileBo();
            FileDetails.MatterId = 1;
            FileDetails.CaseModuleCode = "CR";
            FileDetails.FileName = "Code.txt";
            CaseFile = ReadFileFromFileSystem(@"C:\UploadedDocs", FileDetails);

            result.Data = CaseFile;
            result.Data.FileName = FileDetails.FileName;
            result.IsSuccess = true;
            return result;
        }



        static CaseFileBo ReadFileFromFileSystem(string CorrespondenceRootDirectory, CaseFileBo FileDetails)
        {
            CaseFileBo CaseFile = new CaseFileBo();
            string Folder = CorrespondenceFolderPath(CorrespondenceRootDirectory, FileDetails.MatterId, FileDetails.CaseModuleCode);
            string FilePath = Path.Combine(Folder, FileDetails.FileName);

            if (File.Exists(FilePath))
            {
                CaseFile.FileData = File.ReadAllBytes(FilePath);
            }
            else
            {
                throw new Exception("File not found");
            }

            return CaseFile;
        }

    }




}
