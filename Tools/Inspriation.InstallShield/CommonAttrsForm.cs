using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace InstallShield
{
    public partial class CommonAttrsForm : InstallShield.TemplateForm
    {
        public CommonAttrsForm()
        {
            InitializeComponent();
        }

        XmlNode activeSession;

        private void CommonAttrsForm_Load(object sender, EventArgs e)
        {
            if (!GlobalObjects.isLoaded)
            {
                MessageBox.Show("Please load the active config file first.");
                this.Close();
            }
            else
            {
                activeSession = GlobalObjects.activeConfigObj.Get_SessionNode("commonattr");
                if (activeSession == null)
                {
                    activeSession = GlobalObjects.activeConfigObj.Create_NewSession("commonattr", "", true);
                    GlobalObjects.activeConfigObj.doSave();
                }
                FlushFirstLevelNodes();
                
            }
        }

        private void FlushFirstLevelNodes()
        {
            XmlNodeList items = GlobalObjects.activeConfigObj.Get_ItemNodes("commonattr");
            cmb_node.Items.Clear();
            foreach (XmlNode activeItem in items)
            {
                cmb_node.Items.Add(GlobalObjects.activeConfigObj.Get_AttrValue(activeItem, "name", false));
            }
        }

        private void FlushAttr()
        {
            if (lab_isfirstlevelselected.Text == "True" || lab_isfirstlevelselected.Text == "False")
            {

                XmlNode activeSelectNode = null;
                activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.Text);
                if (activeSelectNode != null)
                {
                    if (lab_isfirstlevelselected.Text == "False")
                    {
                        activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeSelectNode, cmb_secondnode.Text);
                    }
                    if (activeSelectNode != null)
                    {
                        cmb_attrs.Items.Clear();
                        foreach (XmlAttribute attr in activeSelectNode.Attributes)
                        {
                            cmb_attrs.Items.Add(attr.Name);
                        }
                    }
                }

            }           
        }

        private void FlushSecondLevelNodes()
        {
            if (cmb_node.Text != "")
            {
                XmlNode activeParentNode=GlobalObjects.activeConfigObj.Get_ItemNode("commonattr",cmb_node.Text);
                if (activeParentNode != null)
                {
                    cmb_secondnode.Items.Clear();
                    XmlNodeList secondLevelNodes = activeParentNode.SelectNodes("item");
                    foreach (XmlNode activeSecondLevelNode in secondLevelNodes)
                    {
                        cmb_secondnode.Items.Add(Inspriation.Lib.AwsXmlHelper.GetNodeValue("@name", activeSecondLevelNode));
                    }
                }               

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!cmb_node.Items.Contains(cmb_node.Text))
            {
                if (cmb_node.Text != "")
                {
                    GlobalObjects.activeConfigObj.Create_Item(activeSession, cmb_node.Text, txt_nodevalue.Text, true);
                    MessageBox.Show("You have created the new node.");
                    FlushFirstLevelNodes();
                }
                else
                    MessageBox.Show("Please enter the name for the new node first.");
            }
            else
                MessageBox.Show("The node is existed in the nodes list,please change the node name.");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_node.Text != "")
            {
                XmlNode activeItem = GlobalObjects.activeConfigObj.Get_ItemNode(activeSession, cmb_node.Text);
                if (activeItem == null)
                {
                    MessageBox.Show("The node is not existed,please check the node name first.");
                    return;
                }
                else
                {
                    GlobalObjects.activeConfigObj.Remove_SessionItem("commonattr", cmb_node.Text);
                    FlushFirstLevelNodes();
                }
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_secondnode.Text != "" && cmb_node.Text != "")
            {
                XmlNode activeItemNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.Text);
                if (activeItemNode != null)
                {
                    GlobalObjects.activeConfigObj.Create_Item(activeItemNode, cmb_secondnode.Text, txt_childvalue.Text, true);
                    FlushSecondLevelNodes();
                }
                else
                    MessageBox.Show("The selected parent node is not existed,please check again.");
            }
            else
                MessageBox.Show("Please select the parent node name first.");
        }

        private void cmb_node_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab_selectednode.Text = cmb_node.Text;
            lab_isfirstlevelselected.Text = "True";
            lab_attrnodeselected.Text = cmb_node.Text;
            FlushSecondLevelNodes();
            FlushAttr();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmb_secondnode.Text != "" && cmb_node.SelectedText != "")
            {
                XmlNode activeItemNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.SelectedText);
                if (activeItemNode != null)
                {
                    GlobalObjects.activeConfigObj.Remove_ActiveItem(activeItemNode, cmb_secondnode.Text);
                    FlushSecondLevelNodes();
                }
                else
                    MessageBox.Show("The selected parent node is not existed,please check again.");
            }
            else
                MessageBox.Show("Please select the parent node name first.");
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lab_isfirstlevelselected.Text == "True" || lab_isfirstlevelselected.Text == "False")
            {
                if (cmb_attrs.Text != "")
                {
                    XmlNode activeSelectNode=null;
                    activeSelectNode=GlobalObjects.activeConfigObj.Get_ItemNode("commonattr",cmb_node.Text);
                    if (activeSelectNode != null)
                    {
                        if (lab_isfirstlevelselected.Text == "False")
                        {
                            activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeSelectNode, cmb_secondnode.Text);
                        }
                        if (activeSelectNode != null)
                        {
                            GlobalObjects.activeConfigObj.Set_ItemAttr(activeSelectNode, cmb_attrs.Text, "", true);
                            FlushAttr();
                            MessageBox.Show("You have create the new attribute.");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select the active node first.");
        }

        private void cmb_secondnode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lab_isfirstlevelselected.Text = "False";
            lab_attrnodeselected.Text = cmb_secondnode.Text;
            FlushAttr();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lab_isfirstlevelselected.Text == "True" || lab_isfirstlevelselected.Text == "False")
            {
                if (cmb_attrs.Text != "")
                {
                    XmlNode activeSelectNode = null;
                    activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.Text);
                    if (activeSelectNode != null)
                    {
                        if (lab_isfirstlevelselected.Text == "False")
                        {
                            activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeSelectNode, cmb_secondnode.Text);
                        }
                        if (activeSelectNode != null)
                        {
                            activeSelectNode.Attributes.Remove(activeSelectNode.Attributes[cmb_attrs.Text]);
                            FlushAttr();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select the active node first.");
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lab_isfirstlevelselected.Text == "True" || lab_isfirstlevelselected.Text == "False")
            {
                if (cmb_attrs.Text != "")
                {
                    XmlNode activeSelectNode = null;
                    activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.Text);
                    if (activeSelectNode != null)
                    {
                        if (lab_isfirstlevelselected.Text == "False")
                        {
                            activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeSelectNode, cmb_secondnode.Text);
                        }
                        if (activeSelectNode != null)
                        {
                            GlobalObjects.activeConfigObj.Set_ItemAttr(activeSelectNode, cmb_attrs.Text, txt_attrValue.Text, true);
                            FlushAttr();
                            MessageBox.Show("You have updated the attr value.");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Please select the active node first.");
        }

        private void cmb_attrs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lab_isfirstlevelselected.Text == "True" || lab_isfirstlevelselected.Text == "False")
            {
                if (cmb_attrs.Text != "")
                {
                    XmlNode activeSelectNode = null;
                    activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode("commonattr", cmb_node.Text);
                    if (activeSelectNode != null)
                    {
                        if (lab_isfirstlevelselected.Text == "False")                        
                            activeSelectNode = GlobalObjects.activeConfigObj.Get_ItemNode(activeSelectNode, cmb_secondnode.Text);                        
                        if (activeSelectNode != null)
                            txt_attrValue.Text= GlobalObjects.activeConfigObj.Get_AttrValue(activeSelectNode, cmb_attrs.Text, true);                        
                        
                    }
                }
            }
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GlobalObjects.activeConfigObj.doSave();
            MessageBox.Show("You have saved the config file.");
        }

        

    }
}
