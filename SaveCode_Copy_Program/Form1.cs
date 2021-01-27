using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace SaveCode_Copy_Program
{
    public partial class form_main : Form
    {
        string dirPath;
        string playerName;
        int saveNum;
        int exp;
        bool noFile;

        string saveCode;

        public form_main()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            String userName = Environment.UserName;
            dirPath = @"C:\Users\" + userName + @"\Documents\Warcraft III\CustomMapData\DRD\DRDR2\";

            path_check();
 

        }

        // 카페 홈페이지 버튼
        private void link_homePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cafe.naver.com/digimondefence");
        }

        // 세이브 보상 버튼
        private void link_rewardList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://cafe.naver.com/digimondefence/209");
        }

        // 코드 복사 버튼
        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(saveCode);
            MessageBox.Show(saveCode+"\n붙여넣기 : Ctrl + V", "코드 복사 완료!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void path_check()
        {
            // First 경로가 존재할 경우 -> 데이터 로드
            if (System.IO.Directory.Exists(dirPath))
            {
                data_load();
            }
            // First 경로가 존재하지 않을 경우 -> 사용자 지정 경로 확인
            else
            {
                // 사용자 지정 경로가 존재할 경우
                if(File.Exists(Application.StartupPath + @"\customPath.txt"))
                {
                    StreamReader sr = new StreamReader("customPath.txt");
                    string customPath = sr.ReadLine();
                    sr.Close();

                    // 불러온 경로가 손상되지 않았는지 검사
                    if (System.IO.Directory.Exists(customPath))
                    {
                        // 사용자 지정 경로가 "정상적" 으로 존재할 경우
                        dirPath = customPath;
                        data_load();
                    }
                    else
                    {
                        // 사용자 지정 경로가 "정상적" 으로 존재하지 않을 경우
                        System.IO.File.Delete(Application.StartupPath + @"\customPath.txt");
                        path_check();
                    }
                }
                // 사용자 지정 경로가 존재하지 않을 경우 -> 사용자 지정 경로 설정
                else
                {
                    // 사용자 지정 경로 설정? -> 예
                    if (MessageBox.Show(
                        "세이브파일이 저장된 경로를 찾을 수 없습니다.\n\n사용자 지정 경로를 설정 하시겠습니까?",
                        "경로를 찾을 수 없음",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        CommonOpenFileDialog folderDlog = new CommonOpenFileDialog();
                        folderDlog.IsFolderPicker = true; // 폴더 선택

                        while (true)
                        {
                            // 폴더 다이얼로그 -> 폴더 선택 버튼
                            if (folderDlog.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                string[] selectDir = folderDlog.FileName.Split('\\');
                                // 사용자 지정 경로를 제대로 설정한 경우
                                if (selectDir[selectDir.Length - 1].Equals("DRDR2") && selectDir[selectDir.Length - 2].Equals("DRDR"))
                                {
                                    break;
                                }
                                // 사용자 지정 경로 설정을 제대로 하지 않았을 경우
                                else
                                {
                                    MessageBox.Show("DRDR\\DRDR2 폴더가 아닙니다.\n" + folderDlog.FileName, "사용자 지정 경로 설정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            // 폴더 다이얼로그 -> 취소 버튼
                            else
                            {
                                if (MessageBox.Show(
                                    "프로그램을 종료 하시겠습니까?",
                                    "프로그램 종료",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question) == DialogResult.Yes)
                                // 사용자 지정 경로를 설정하지 않고 프로그램을 종료 시킴.
                                {
                                    break;
                                    Application.Exit();
                                }
                            }
                        }

                        // 사용자 지정 경로를 제대로 설정한 경우 -> 사용자 지정 경로 데이터 파일 저장
                        StreamWriter sw = new StreamWriter("customPath.txt");
                        sw.WriteLine(folderDlog.FileName);
                        sw.Close();

                        path_check();
                    }
                    // 사용자 지정 경로 설정? -> 아니오
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void data_load()
        {
            string[] fileDummy = Directory.GetFiles(dirPath, "[디지몬랜덤디펜스 *]*.txt");
            // 세이브 파일이 하나도 존재하지 않는 경우
            if (fileDummy.Length.Equals(0))
            {
                noFile = true;
                btn_Copy.Enabled = false;
            }

            // 디렉토리 및 파일이 정상적으로 존재 하는 경우
            else
            {
                noFile = false;
                btn_Copy.Enabled = true;
                data_extract();
            }
            file_print();
            version_Load();
            file_watcher();
        }

        // 파일을 읽어들임.
        private void data_extract()
        {
            // Directory Info Class 생성
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(dirPath);

            string temp = "";
            string focusFile = "";
            string[] dummy = { };

            foreach (var item in di.GetFiles())
            {

                dummy = item.Name.Split('\x020');

                // 가장 높은 세이브 값을 찾는 작업
                // dummy[2] 값이 더 클 때 temp를 업데이트 함.
                if (String.Compare(dummy[2], temp) > 0)
                {
                    temp = dummy[2];
                    focusFile = item.FullName;
                }
                //playerName = dummy[1].Replace("]", "");
            }

            // 플레이어 이름 추출
            playerName = dummy[1].Replace("]", "");

            string[] line_string;
            string[] textValue = System.IO.File.ReadAllLines(focusFile);

            // 세이브 코드 추출
            line_string = new string[3];
            line_string = textValue[3].Split('\"');
            saveCode = line_string[1].Replace("코드: ", "");

            // 세이브 횟수 추출
            line_string = new string[3];
            line_string = textValue[4].Split('\"');
            saveNum = Convert.ToInt32(line_string[1].Replace("등급: ", ""));

            // 경험치 추출
            line_string = new string[3];
            line_string = textValue[5].Split('\"');
            exp = Convert.ToInt32(line_string[1].Replace("보유 점수: ", ""));
        }

        // 데이터 출력.
        private void file_print()
        {
            if (noFile.Equals(true))
            {
                lbl_playerName.Text = "unknown";
                lbl_saveNum.Text = "0 회";
                lbl_exp.Text = "0 점";
            }
            else
            {
                lbl_playerName.Text = playerName;
                lbl_saveNum.Text = saveNum + " 회";
                lbl_exp.Text = exp + " 점";
            }
        }

        // 파일 왓쳐 : 프로그램이 켜져 있는동안 새로운 세이브 코드 업데이트를 감시함.
        private void file_watcher()
        {
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            watcher.Path = dirPath;
            watcher.NotifyFilter = NotifyFilters.FileName;

            watcher.Created += new FileSystemEventHandler(Changed);
            watcher.Deleted += new FileSystemEventHandler(Changed);
            watcher.EnableRaisingEvents = true;
        }

        // 프로그램에 새 세이브 코드 업데이트 적용.
        private void Changed(object source, FileSystemEventArgs e)
        {
            data_load();
            file_print();
        }

        // 최신 빌드 정보를 로드함.
        private void version_Load()
        {
            System.Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(assemblyVersion.Build).AddSeconds(assemblyVersion.Revision * 2);

            lbl_buildDate.Text = "[마지막 빌드 : " + buildDate.ToString("yyyy-MM-dd") + "]";
            lbl_buildDate.Location = new Point(lbl_buildDate.Location.X, lbl_buildDate.Location.Y);

        }

    }
}
