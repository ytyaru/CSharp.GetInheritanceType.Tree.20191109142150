using System;
using System.Linq;
using System.Reflection;

namespace GetInheritanceType
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aの子のみ");
            foreach (var t in AssemblyUtils.GetChildren<A>()) {Console.WriteLine($"{t}");}
            Console.WriteLine();
            Console.WriteLine("Aの子孫すべて");
            foreach (var t in AssemblyUtils.GetInheritanceTypes<A>()) {Console.WriteLine($"{t}");}
            Console.WriteLine();
            Console.WriteLine("Aの末裔すべて");
            foreach (var t in AssemblyUtils.GetEndInheritanceTypes<A>()) {Console.WriteLine($"{t}");}
            Console.WriteLine();
            Console.WriteLine("Aの子孫すべてをツリーで。");
            TypeNode node = AssemblyUtils.GetInheritanceTypeTree<A>();
            ShowNode(node);
        }
        private static void ShowNode(TypeNode node, int index=0)
        {
            if (null != node) { Console.WriteLine($"{(new string('*', index)).Replace("*", "    ")}{node.Type.Name}"); }
            if (null != node?.Children) {
                index++;
                foreach (var n in node.Children) { ShowNode(n, index); }
            }
        }
    }
}
