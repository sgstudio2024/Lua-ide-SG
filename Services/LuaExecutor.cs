using NLua;
using System;

namespace SG_Lua_IDE.Services
{
    public class LuaExecutor
    {
        private readonly Lua _lua;

        public LuaExecutor()
        {
            _lua = new Lua();
            SetupEnvironment();
        }

        private void SetupEnvironment()
        {
            // 重定向print函数到控制台输出
            _lua.DoString("print = function(...) for i,v in ipairs({...}) do output(tostring(v)) end end");
            
            // 添加基本库
            _lua.LoadCLRPackage();
            
            // 注册常用函数
            _lua.RegisterFunction("output", typeof(LuaExecutor).GetMethod("Output"));
        }

        public void Execute(string code)
        {
            try
            {
                _lua.DoString(code);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lua Error: {ex.Message}");
            }
        }
        
        // Lua调用的输出函数
        public static void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}