using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Poker_Wizard;
using MsgBox;
using Poker_Wizard.Properties;
using IniParser;
using IniParser.Model;

public class TableLayoutPanelArray : System.Collections.CollectionBase
{
    private readonly Panel HostForm;

    private List<Label> lblPlace = new List<Label>();
    private List<Label> lblRebuys = new List<Label>();
    private List<Label> lblBounties = new List<Label>();
    private List<Button> btnAddRebuy = new List<Button>();
    private List<Button> btnRemove = new List<Button>();
    private int PlayersLeft { get; set; }
    private string lastPlayerWithBounty = "";
    private FrmMain frmMain;

    private FileIniDataParser fileIniData = new FileIniDataParser();
    private IniData settings;

    public TableLayoutPanelArray(Panel host, FrmMain form)
    {
        settings = fileIniData.ReadFile(Settings.Default.IniFile);
        HostForm = host;
        frmMain = form;
        //this.AddNewPanel();
    }

    public void ReadIni()
    {
        settings = fileIniData.ReadFile(Settings.Default.IniFile);
    }

    public Label NewPlaceLabel()
    {
        Label label = new Label
        {
            Text = "",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Margin = new System.Windows.Forms.Padding(1, 1, 1, 1),
            Tag = this.Count
        };

        return label;
    }

    public Label NewRebuyLabel()
    {
        Label label = new Label
        {
            Text = "0",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Margin = new System.Windows.Forms.Padding(1, 1, 1, 1),
            Tag = this.Count
        };

        return label;
    }

    public Label NewBountyLabel()
    {
        Label label = new Label
        {
            Text = "0",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Margin = new System.Windows.Forms.Padding(1, 1, 1, 1),
            Tag = this.Count
        };

        return label;
    }

    public Button NewAddRebuyButton(CurrentGameData currentGameData)
    {
        Button button = new Button
        {
            Text = "Add Rebuy",
            BackColor = Color.Gainsboro,
            Dock = DockStyle.Fill,
            Margin = new System.Windows.Forms.Padding(0, 0, 50, 0),
            Tag = this.Count,
            Enabled = false
        };
        button.Click += new EventHandler((sender, e) => AddRebuyClickHandler(sender, e, this.List.IndexOf(((Button)sender).Parent), currentGameData));
        button.TabStop = false;

        return button;
    }

    public Button NewRemoveButton(CurrentGameData currentGameData)
    {
        Button button = new Button
        {
            Text = "Remove",
            BackColor = Color.Gainsboro,
            Dock = DockStyle.Fill,
            Margin = new System.Windows.Forms.Padding(0, 0, 51, 0),
            Tag = this.Count
        };
        button.Click += new EventHandler((sender, e) => RemoveClickHandler(sender, e, this.List.IndexOf(((Button)sender).Parent), currentGameData));
        button.TabStop = false;

        return button;
    }

    public TableLayoutPanel AddNewPanel(TableLayoutPanel header, CurrentGameData currentGameData)
    {
        // Create a new instance of the Button class.
        TableLayoutPanel newPanel = new TableLayoutPanel();
        // Add the button to the collection's internal list.
        this.List.Add(newPanel);

        ((Panel)header.Parent).AutoScrollPosition = new Point(0, 0);
        
        // Add the button to the controls collection of the form 
        // referenced by the HostForm field.
        HostForm.Controls.Add(newPanel);
        // Set intial properties for the button object.
        newPanel.Top = Count * 67;
        
        
        newPanel.Left = 6;
        newPanel.Width = header.Width;//753;
        newPanel.Height = 52;
        newPanel.ColumnCount = 6;

        // Determine if the bounty column should be shown
        if (!Equals(settings[Settings.Default.IniSection]["Bounties"], "0"))
        {
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
        }
        else
        {
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            newPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        }
        
        newPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        newPanel.Tag = this.Count.ToString();

        lblPlace.Add(NewPlaceLabel());
        newPanel.Controls.Add(lblPlace[Count - 1], 0, 0);

        Label lblPlayer = new Label();
        newPanel.Controls.Add(lblPlayer, 1, 0);
        lblPlayer.Text = currentGameData.players[currentGameData.players.Count - 1].Name;
        lblPlayer.Dock = DockStyle.Fill;
        lblPlayer.TextAlign = ContentAlignment.MiddleCenter;
        lblPlayer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
        lblPlayer.Tag = this.Count;

        lblRebuys.Add(NewRebuyLabel());
        newPanel.Controls.Add(lblRebuys[Count - 1], 2, 0);

        lblBounties.Add(NewBountyLabel());
        newPanel.Controls.Add(lblBounties[Count - 1], 3, 0);

        btnAddRebuy.Add(NewAddRebuyButton(currentGameData));
        newPanel.Controls.Add(btnAddRebuy[Count - 1], 4, 0);

        btnRemove.Add(NewRemoveButton(currentGameData));
        newPanel.Controls.Add(btnRemove[Count - 1], 5, 0);
        //btnRemove.Text = "Remove";
        //btnRemove.BackColor = Color.Gainsboro;
        //btnRemove.Dock = DockStyle.Fill;
        //btnRemove.Margin = new System.Windows.Forms.Padding(0, 0, 51, 0);
        //btnRemove.Tag = this.Count;
        //btnRemove.Click += new EventHandler(this.RemoveClickHandler);

        PlayersLeft++;


        using (Control c = new Control() { Parent = ((Panel)header.Parent), Dock = DockStyle.Bottom })
        {
            ((Panel)header.Parent).ScrollControlIntoView(c);
            c.Parent = null;
        }

        return newPanel;

    }

    public TableLayoutPanel this[int Index]
    {
        get
        {
            return (TableLayoutPanel)this.List[Index];
        }
    }

    public void Remove(Object sender)
    {
        int index;
        // Check to be sure there is a button to remove.
        if (this.Count > 0)
        {
            // Remove the last button added to the array from the host form 
            // controls collection. Note the use of the indexer in accessing 
            // the array.
            //HostForm.Controls.Remove(this[this.Count - 1]);
            ((Panel)((TableLayoutPanel)((Button)sender).Parent).Parent).AutoScrollPosition = new Point(0, 0);
            index = this.List.IndexOf(((Button)sender).Parent);
            //index = HostForm.Controls.IndexOf(((Button)sender).Parent);
            HostForm.Controls.Remove(this[index]);
            //this.List.RemoveAt(this.Count - 1);
            this.List.RemoveAt(index);
            lblPlace.RemoveAt(index);
            lblRebuys.RemoveAt(index);
            lblBounties.RemoveAt(index);
            btnAddRebuy.RemoveAt(index);
            btnRemove.RemoveAt(index);
            RepositionPanels();

        }
    }

    private void RepositionPanels()
    {
        int index = 0;
        foreach (TableLayoutPanel c in this)
        {
            index++;
            c.Top = index * 67;
        }
    }

    public void DisableRemoveButtons()
    {
        for (int i = 0; i < btnRemove.Count; i++)
        {
            btnRemove[i].Enabled = false;
        }
    }

    public void DisableRebuyButtons()
    {
        for (int i = 0; i < btnAddRebuy.Count; i++)
        {
            btnAddRebuy[i].Enabled = false;
        }
    }

    public void EnableRemoveButtons()
    {
        for (int i = 0; i < btnRemove.Count; i++)
        {
            btnRemove[i].Enabled = true;
        }
    }

    public void EnableRebuyButtons()
    {
        for (int i = 0; i < btnAddRebuy.Count; i++)
        {
            btnAddRebuy[i].Enabled = true;
        }
    }

    public void AddRebuyClickHandler(Object sender, EventArgs e, int playerIndex, CurrentGameData currentGameData)
    {
        PlayerData player = currentGameData.players[playerIndex];

        if (player.Rebuys < Int32.Parse(settings[Settings.Default.IniSection]["MaximumRebuys"]))
        {
            player.Rebuys++;
            lblRebuys[playerIndex].Text = player.Rebuys.ToString();
        }
        else
        {
            player.Rebuys = 0;
            lblRebuys[playerIndex].Text = player.Rebuys.ToString();
        }

            
        // If bounties is set to On Re-buy, show bounty pop up
        if (Equals(settings[Settings.Default.IniSection]["Bounties"], "1"))
        {
            AddBounty(player, playerIndex, true, sender, currentGameData);
        }
#if DEBUG
        // Output rebuys to console for easy debugging
        Console.Write("Rebuys:\n");
        foreach (PlayerData p in currentGameData.players)
        {
            Console.Write(p.Name + ": " + p.Rebuys + "\n");
        }
        Console.Write("--------\n");
#endif
        ((Panel)((TableLayoutPanel)((Button)sender).Parent).Parent).Focus();

        currentGameData.UpdateCurrentGameData(PlayersLeft);
    }

    public void RemoveClickHandler(Object sender, EventArgs e, int playerIndex, CurrentGameData currentGameData)
    {
        PlayerData player = currentGameData.players[playerIndex];
        int i = 0;
        int index = this.List.IndexOf(((Button)sender).Parent);
        if (currentGameData.State == State.NotStarted)
        {
            currentGameData.players.RemoveAt(playerIndex);
            Remove(sender);
            PlayersLeft--;
        }
        else if (((Button)sender).Text == "Undo")
        {
            PlayersLeft++;
            lblPlace[playerIndex].Text = "";
            player.Eliminated = false;
            player.Place = 0;
            ((Button)sender).Text = "Remove";

            // Loop through players to the player with the last bounty
            foreach (PlayerData playerData in currentGameData.players)
            {
                if (playerData.Name == lastPlayerWithBounty)
                {
                    playerData.Bounties--;
                    lblBounties[i].Text = playerData.Bounties.ToString();
                }
                i++;
            }
        }
        else
        {
            ((Panel)((TableLayoutPanel)((Button)sender).Parent).Parent).AutoScrollPosition = new Point(0, 0);
            ((Button)sender).Text = "Undo";
            // Set place label
            switch (PlayersLeft)
            {
                case 1:
                    lblPlace[index].Text = "1st";
                    break;
                case 2:
                    lblPlace[index].Text = "2nd";
                    break;
                case 3:
                    lblPlace[index].Text = "3rd";
                    break;
                default:
                    lblPlace[index].Text = PlayersLeft + "th";
                    break;


            }

            player.Eliminated = true;
            player.Place = PlayersLeft;
#if DEBUG
            // Output isEliminated to console for easy debugging
            Console.Write("Eliminated:\n");
            foreach (PlayerData playerData in currentGameData.players)
            {
                Console.Write(playerData.Name + ": " + playerData.Eliminated + "\n");
            }
            Console.Write("--------\n");

#endif
            i = 0;
            int j = 0;
            foreach (Control c in this)
            {

                if (c != (TableLayoutPanel)((Button)sender).Parent)
                {
                    if (lblPlace[j].Text.Length == 0)
                    {
                        i++;
                        c.Top = i * 67;
                    }
                    else
                    {
                         btnRemove[j].Enabled = false; //Convert.ToInt32(c.Tag) - 1
                    }
                }
                j++;
            }

            // Reposition Panel to last panel
            ((TableLayoutPanel)((Button)sender).Parent).Top = PlayersLeft * 67;

            PlayersLeft--;

            if (!Equals(settings[Settings.Default.IniSection]["Bounties"], "0"))
            {
                if (PlayersLeft > 0)
                {
                    AddBounty(player, index, false, sender, currentGameData);
                }
            }

            if (PlayersLeft == 1)
            {
                DisableButtons();
                frmMain.EndOfGame(lblPlace);
            }
        }
        currentGameData.UpdateCurrentGameData(PlayersLeft);
    }

    private void DisableButtons()
    {
        btnRemove.ForEach(button => button.Enabled = false);
        btnAddRebuy.ForEach(button => button.Enabled = false);
    }

    public void AddBounty(PlayerData player, int labelIndex, Boolean OnRebuy, Object sender, CurrentGameData currentGameData)
    {
        string[] aPlayers;
        int i = 0;

        if (player.Eliminated)
        {
            aPlayers = new string[PlayersLeft];
        }
        else
        {
            aPlayers = new string[PlayersLeft - 1];
        }

        // Populate array to show in the input box
        foreach (PlayerData playerData in currentGameData.players)
        {
            if (playerData.Name != player.Name)
            {
                if (playerData.Eliminated != true)
                {
                    aPlayers[i] = playerData.Name;
                    i++;
                }
            }
        }

        // Dislpay input box to choose which player got the bounty
        InputBox.ShowDialog("Who kocked this person out.", "Bounty", InputBox.Buttons.OkCancel, InputBox.Type.ComboBox, aPlayers, false, new Font("Arial", 10F, FontStyle.Bold));
        if (InputBox.ResultValue.Length != 0)
        {
            i = 0;

            // Loop through players to find out which panel matches the player chosen
            foreach (PlayerData playerData in currentGameData.players)
            {
                if (playerData.Name == InputBox.ResultValue)
                {
                    playerData.Bounties++;
                    lblBounties[i].Text = playerData.Bounties.ToString();
                    lastPlayerWithBounty = playerData.Name;
                }
                i++;
            }
        }
        else if (OnRebuy)
        {
            player.Rebuys--;
            lblRebuys[labelIndex].Text = player.Rebuys.ToString();
        }
        else
        {
            PlayersLeft++;
            lblPlace[labelIndex].Text = "";
            player.Eliminated = false;
            ((Button)sender).Text = "Remove";
        }

#if DEBUG
        // Output bounties to console for easy debugging
        Console.Write("Bounties:\n");
        foreach (PlayerData playerData in currentGameData.players)
        {
            Console.Write(playerData.Name + ": " + playerData.Bounties + "\n");
        }
        Console.Write("--------\n");
#endif
        currentGameData.UpdateCurrentGameData(PlayersLeft);
    }
}
