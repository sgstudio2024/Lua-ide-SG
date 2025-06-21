using System.IO;
using SG_Lua_IDE.Components;

namespace SG_Lua_IDE.Services
{
    public class FileManager
    {
        public string? CurrentFilePath { get; set; } // 添加可空标识符
        public bool IsEncryptedFile { get; private set; }

        public string OpenFile(string path)
        {
            CurrentFilePath = path;
            
            if (Path.GetExtension(path).ToLower() == ".sglua")
            {
                string encryptedContent = File.ReadAllText(path);
                string decryptedContent = CryptoService.Decrypt(encryptedContent);
                IsEncryptedFile = true;
                return decryptedContent;
            }
            else
            {
                IsEncryptedFile = CryptoService.IsEncryptedFile(path);
                
                if (IsEncryptedFile)
                {
                    string encryptedContent = File.ReadAllText(path);
                    return CryptoService.Decrypt(encryptedContent);
                }
                else
                {
                    return File.ReadAllText(path);
                }
            }
        }

        public void SaveFile(string path, string content)
        {
            CurrentFilePath = path;
            
            if (Path.GetExtension(path).ToLower() == ".sglua")
            {
                string encryptedContent = CryptoService.Encrypt(content);
                File.WriteAllText(path, encryptedContent);
                IsEncryptedFile = true;
            }
            else
            {
                File.WriteAllText(path, content);
                IsEncryptedFile = false;
            }
        }
        
        public void ExportToLua(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}