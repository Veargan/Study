package GUI;

import javax.swing.JPanel;

import API.xComand;

public class Panel extends JPanel
{
	public xComand cmd=null;
	
	public StatusBar sb=null;
	public TabPanel tbp=null;
	public Menu mp=null;
	//
//	public TabComponents tc = null;

	public Panel()
	{
		this.cmd=new xComand();
		setLayout(null);
		
		this.cmd.p=this;
		
		ColorPanel cp;
		WidthPanel wp;
		TypePanel tp;
		ToolBarPanel tb;
		SaveLoadPanel slp;
		
		cp = new ColorPanel(cmd);
		wp=new WidthPanel(cmd);
		tp=new TypePanel(cmd);
		mp = new Menu(cmd);
		tb = new ToolBarPanel(cmd);
		slp = new SaveLoadPanel(cmd);
		
		sb = new StatusBar();
		tbp = new TabPanel();
		//
//		tc = new TabComponents("Ilya");
//		tc.setBounds(170, 70, 600, 500);
//		add(tc);

		mp.setBounds(0, 0,   800, 30);
		tb.setBounds(0, 30,  800, 30);
		cp.setBounds(0, 70,  160, 50);
		wp.setBounds(0, 140, 160, 150);
		tp.setBounds(0, 300, 160, 170);
		slp.setBounds(0, 480, 160, 90);
		
		sb.setBounds(0, 600,800, 50);
		tbp.setBounds(170, 70, 600, 500);
		
		add(cp);
		add(wp);
		add(tp);
		add(mp);
		add(tb);
		add(slp);
		
		add(sb);
		add(tbp);

		//sb.setData(tbp.ppanels.get(tbp.getSelectedIndex()).data);
	}

}
