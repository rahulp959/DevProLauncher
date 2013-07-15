﻿using System;
using System.Windows.Forms;
using DevProLauncher.Config;
using DevProLauncher.Network.Enums;

namespace DevProLauncher.Windows.MessageBoxs
{
    public partial class ProfileFrm : Form
    {
        private readonly string m_profileUsername;

        public ProfileFrm()
        {
            m_profileUsername = Program.UserInfo.username;
            InitializeComponent();
            ApplyTranslation();
            Username.Text += Program.UserInfo.username;
            Program.ChatServer.UserStats += ProfileUpdate;
            FormClosed += OnClose;

        }

        public ProfileFrm(string username)
        {
            m_profileUsername = username;
            InitializeComponent();
            ApplyTranslation();
            Username.Text += username;
            Program.ChatServer.UserStats += ProfileUpdate;

        }
        public void OnClose(object sender, EventArgs e)
        {
            if (Program.ChatServer.UserStats != null) 
// ReSharper disable DelegateSubtraction
                Program.ChatServer.UserStats -= ProfileUpdate;
// ReSharper restore DelegateSubtraction
        }

        public void ApplyTranslation()
        {
            LanguageInfo language = Program.LanguageManager.Translation;

            Text = language.profileName;
            Username.Text = language.profileLblUsername;
            rank.Text = language.profileLblRank;
            team.Text = language.profileLblTeam;
            groupBox4.Text = language.profileLblwld;
            groupBox2.Text = language.profileGb2;
            groupBox3.Text = language.profileGb3;
            groupBox5.Text = language.profileGb4;
            groupBox6.Text = language.profileGb5;
            groupBox1.Text = language.profileGb1;
            rwin.Text = language.profileWin;
            uwin.Text = language.profileWin;
            rlose.Text = language.profileLose;
            ulose.Text = language.profileLose;

            //unranked
            txtUWinLP0.Text = language.profileLblLP;
            txtUWinSurrendered.Text = language.profileLblSurrendered;
            txtUWin0Cards.Text = language.profileLbl0Cards;
            txtUWinTimeLimit.Text = language.profileLblTimeLimit;
            txtUWinRageQuit.Text = language.profileLblDisconnect;
            txtUWinExodia.Text = language.profileLblExodia;
            txtUWinCountdown.Text = language.profileLblFinalCountdown;
            txtUWinVennominaga.Text = language.profileLblVennominaga;
            txtUWinHorakhty.Text = language.profileLblHorakhty;
            txtUWinExodius.Text = language.profileLblExodius;
            txtUWinDestinyBoard.Text = language.profileLblDestinyBoard;
            txtUWinLastTurn.Text = language.profileLblLastTurn;
            txtUWinDestinyLeo.Text = language.profileLblDestinyLeo;
            txtUWinUnknown.Text = language.profileLblUnknown;

        }

        private void ProfileUpdate(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ProfileUpdate), message);
            }
            else
            {

                if (!IsDisposed)
                {
                    string[] sections = message.Split(new[] {"||"}, StringSplitOptions.None);
                    rank.Text += sections[0];
                    UserLevel.Text = "Lvl: " + sections[5];
                    if (sections[1] == "not found")
                        MatchWLD.Text = "0/0/0";
                    else
                    {
                        string[] values = sections[1].Split(',');
                        MatchWLD.Text = values[0] + "/" + values[1] + "/" + values[2];
                        SingleWLD.Text = values[3] + "/" + values[4] + "/" + values[5];
                        TagWLD.Text = values[6] + "/" + values[7] + "/" + values[8];
                    }
                    team.Text += sections[2];
                    string[] unrankedparts = sections[3].Split(',');
                    string[] rankedparts = sections[4].Split(',');

                    if (unrankedparts[0] != "NotFound")
                    {
                        UWinLP0.Text = unrankedparts[0];
                        UWinSurrendered.Text = unrankedparts[1];
                        UWin0Cards.Text = unrankedparts[2];
                        UWinTimeLimit.Text = unrankedparts[3];
                        UWinRageQuit.Text = unrankedparts[4];
                        UWinExodia.Text = unrankedparts[5];
                        UWinCountdown.Text = unrankedparts[6];
                        UWinVennominaga.Text = unrankedparts[7];
                        UWinHorakhty.Text = unrankedparts[8];
                        UWinExodius.Text = unrankedparts[9];
                        UWinDestinyBoard.Text = unrankedparts[10];
                        UWinLastTurn.Text = unrankedparts[11];
                        UWinDestinyLeo.Text = unrankedparts[12];
                        UWinUnknown.Text = unrankedparts[13];

                        ULOSELP0.Text = unrankedparts[14];
                        ULOSESurrendered.Text = unrankedparts[15];
                        ULOSE0Cards.Text = unrankedparts[16];
                        ULOSETimeLimit.Text = unrankedparts[17];
                        ULOSERageQuit.Text = unrankedparts[18];
                        ULOSEExodia.Text = unrankedparts[19];
                        ULOSECountdown.Text = unrankedparts[20];
                        ULOSEVennominaga.Text = unrankedparts[21];
                        ULOSEHorakhty.Text = unrankedparts[22];
                        ULOSEExodius.Text = unrankedparts[23];
                        ULOSEDestinyBoard.Text = unrankedparts[24];
                        ULOSELastTurn.Text = unrankedparts[25];
                        ULOSEDestinyLeo.Text = unrankedparts[26];
                        ULOSEUnknown.Text = unrankedparts[27];
                    }

                    if (rankedparts[0] != "NotFound")
                    {
                        RWinLP0.Text = rankedparts[0];
                        RWinSurrendered.Text = rankedparts[1];
                        RWin0Cards.Text = rankedparts[2];
                        RWinTimeLimit.Text = rankedparts[3];
                        RWinRageQuit.Text = rankedparts[4];
                        RWinExodia.Text = rankedparts[5];
                        RWinCountdown.Text = rankedparts[6];
                        RWinVennominaga.Text = rankedparts[7];
                        RWinHorakhty.Text = rankedparts[8];
                        RWinExodius.Text = rankedparts[9];
                        RWinDestinyBoard.Text = rankedparts[10];
                        RWinLastTurn.Text = rankedparts[11];
                        RWinDestinyLeo.Text = rankedparts[12];
                        RWinUnknown.Text = rankedparts[13];

                        RLOSELP0.Text = rankedparts[14];
                        RLOSESurrendered.Text = rankedparts[15];
                        RLOSE0Cards.Text = rankedparts[16];
                        RLOSETimeLimit.Text = rankedparts[17];
                        RLOSERageQuit.Text = rankedparts[18];
                        RLOSEExodia.Text = rankedparts[19];
                        RLOSECountdown.Text = rankedparts[20];
                        RLOSEVennominaga.Text = rankedparts[21];
                        RLOSEHorakhty.Text = rankedparts[22];
                        RLOSEExodius.Text = rankedparts[23];
                        RLOSEDestinyBoard.Text = rankedparts[24];
                        RLOSELastTurn.Text = rankedparts[25];
                        RLOSEDestinyLeo.Text = rankedparts[26];
                        RLOSEUnknown.Text = rankedparts[27];
                    }

                    

                }
            }
        }

        private void Profile_frm_Load(object sender, EventArgs e)
        {
            Program.ChatServer.SendPacket(DevServerPackets.Stats, m_profileUsername);
        }
    }
}
