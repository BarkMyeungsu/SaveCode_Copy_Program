
namespace SaveCode_Copy_Program
{
    partial class form_main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_main));
            this.btn_Copy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.link_homePage = new System.Windows.Forms.LinkLabel();
            this.lbl_saveNum = new System.Windows.Forms.Label();
            this.lbl_exp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_playerName = new System.Windows.Forms.Label();
            this.link_rewardList = new System.Windows.Forms.LinkLabel();
            this.lbl_buildDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(14, 127);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(91, 23);
            this.btn_Copy.TabIndex = 0;
            this.btn_Copy.Text = "코드 복사";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 999;
            this.label1.Text = "세이브 횟수 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 999;
            this.label2.Text = "EXP : ";
            // 
            // link_homePage
            // 
            this.link_homePage.AutoSize = true;
            this.link_homePage.Location = new System.Drawing.Point(250, 115);
            this.link_homePage.Name = "link_homePage";
            this.link_homePage.Size = new System.Drawing.Size(93, 12);
            this.link_homePage.TabIndex = 2;
            this.link_homePage.TabStop = true;
            this.link_homePage.Tag = "";
            this.link_homePage.Text = "디랜디 홈페이지";
            this.link_homePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_homePage_LinkClicked);
            // 
            // lbl_saveNum
            // 
            this.lbl_saveNum.AutoSize = true;
            this.lbl_saveNum.Location = new System.Drawing.Point(95, 40);
            this.lbl_saveNum.Name = "lbl_saveNum";
            this.lbl_saveNum.Size = new System.Drawing.Size(59, 12);
            this.lbl_saveNum.TabIndex = 999;
            this.lbl_saveNum.Text = "saveNum";
            // 
            // lbl_exp
            // 
            this.lbl_exp.AutoSize = true;
            this.lbl_exp.Location = new System.Drawing.Point(95, 61);
            this.lbl_exp.Name = "lbl_exp";
            this.lbl_exp.Size = new System.Drawing.Size(26, 12);
            this.lbl_exp.TabIndex = 999;
            this.lbl_exp.Text = "exp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 999;
            this.label3.Text = "플레이어 : ";
            // 
            // lbl_playerName
            // 
            this.lbl_playerName.AutoSize = true;
            this.lbl_playerName.Location = new System.Drawing.Point(95, 18);
            this.lbl_playerName.Name = "lbl_playerName";
            this.lbl_playerName.Size = new System.Drawing.Size(74, 12);
            this.lbl_playerName.TabIndex = 999;
            this.lbl_playerName.Text = "playerName";
            // 
            // link_rewardList
            // 
            this.link_rewardList.AutoSize = true;
            this.link_rewardList.Location = new System.Drawing.Point(274, 93);
            this.link_rewardList.Name = "link_rewardList";
            this.link_rewardList.Size = new System.Drawing.Size(69, 12);
            this.link_rewardList.TabIndex = 1;
            this.link_rewardList.TabStop = true;
            this.link_rewardList.Text = "세이브 보상";
            this.link_rewardList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_rewardList_LinkClicked);
            // 
            // lbl_buildDate
            // 
            this.lbl_buildDate.AutoSize = true;
            this.lbl_buildDate.Location = new System.Drawing.Point(190, 141);
            this.lbl_buildDate.Name = "lbl_buildDate";
            this.lbl_buildDate.Size = new System.Drawing.Size(153, 12);
            this.lbl_buildDate.TabIndex = 1000;
            this.lbl_buildDate.Text = "[마지막 빌드 : 0000-00-00]";
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(351, 162);
            this.Controls.Add(this.lbl_buildDate);
            this.Controls.Add(this.link_rewardList);
            this.Controls.Add(this.lbl_playerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_exp);
            this.Controls.Add(this.lbl_saveNum);
            this.Controls.Add(this.link_homePage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Copy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_main";
            this.Text = "디랜디 세이브코드 복사 프로그램";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel link_homePage;
        private System.Windows.Forms.Label lbl_saveNum;
        private System.Windows.Forms.Label lbl_exp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_playerName;
        private System.Windows.Forms.LinkLabel link_rewardList;
        private System.Windows.Forms.Label lbl_buildDate;
    }
}

