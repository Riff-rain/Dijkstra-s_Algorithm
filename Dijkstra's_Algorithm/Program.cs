using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Dijkstra_s_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            while(true)
            {
                Console.WriteLine("\n명령어를 입력하세요.");
                Console.Write("Node 입력 : 서울 1, 1 // Edge 입력 : 서울 대전 1 // 파일 입력 : file // 입력 종료 : exit >> ");
                string command = Console.ReadLine();

                switch(command)
                {
                    case "exit" :
                        Console.WriteLine("입력을 종료합니다.");
                        goto EndInput;
                    case "file" :
                        Console.Write("\n파일 주소를 입력하세요. >> ");
                        string filePath = Console.ReadLine();
                        System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                        string file_command;
                        while((file_command = file.ReadLine()) != null)
                        {
                            if (new Regex(@"^[a-zA-Z가-힣]+\s\d+,\s*\d+$").IsMatch(file_command))
                            {
                                string[] file_node_temp = file_command.Replace(',', ' ').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                graph.AddNode(file_node_temp[0], int.Parse(file_node_temp[1]), int.Parse(file_node_temp[2]));
                            }
                            else if(new Regex(@"^[a-zA-Z가-힣]+\s[a-zA-Z가-힣]+\s\d+$").IsMatch(file_command))
                            {
                                string[] file_edge_temp = file_command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                graph.AddEdge(file_edge_temp[0], file_edge_temp[1], int.Parse(file_edge_temp[2]));
                            }
                            else
                            {
                                Console.WriteLine("유효하지 않은 입력입니다.");
                            }
                        }
                        break;
                    case var pattern when new Regex(@"^[a-zA-Z가-힣]+\s\d+,\s*\d+$").IsMatch(pattern):
                        string[] node_temp = command.Replace(',', ' ').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        graph.AddNode(node_temp[0], int.Parse(node_temp[1]), int.Parse(node_temp[2]));
                        break;
                    case var pattern when new Regex(@"^[a-zA-Z가-힣]+\s[a-zA-Z가-힣]+\s\d+$").IsMatch(pattern):
                        string[] edge_temp = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        graph.AddEdge(edge_temp[0], edge_temp[1], int.Parse(edge_temp[2]));
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 입력입니다.");
                        break;
                }
            }

            EndInput:
            while(true)
            {
                Console.WriteLine("\n출발지와 목적지를 입력하세요");
                Console.Write("출발지 및 목적지 입력 : 서울 대전 // 입력 종료 : exit >> ");
                string command = Console.ReadLine();

                switch(command)
                {
                    case "exit":
                        Console.WriteLine("프로그램을 종료합니다.");
                        goto EndProgram;
                    case var pattern when new Regex(@"^[a-zA-Z가-힣]+\s[a-zA-Z가-힣]+$").IsMatch(pattern):
                        string[] temp = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Node destination = graph.Dijkstra(temp[0], temp[1]);
                        Console.WriteLine(temp[0] + "에서 " + temp[1] + "(으)로 가는 최단 거리는 " + destination.Value + "입니다.");
                        Console.Write("경로는 " + destination.ShortestPath[0].Name);
                        for(int i = 1; i < destination.ShortestPath.Count; i++)
                        {
                            Console.Write(" -> ");
                            Console.Write(destination.ShortestPath[i].Name);
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 입력입니다.");
                        break;
                }
            }

            EndProgram:;
        }
    }
}
