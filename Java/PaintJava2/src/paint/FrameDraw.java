package paint;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class FrameDraw extends JFrame
{
	public FrameDraw()
	{
		setTitle("Paint app");
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setBounds(600, 150, 600, 670);

		FSets sets = new FSets();
		PCommands cmd = new PCommands();
		cmd.sets = sets;

		PColor pc = new PColor(cmd);
		PWidth pw = new PWidth(cmd);
		PFigure pf = new PFigure(cmd);
		PanelDraw pd = new PanelDraw(cmd);

		pc.setBounds(0, 0, 200, 200);
		pd.setBounds(200, 0, 400, 600);
		pw.setBounds(0, 200, 200, 200);
		pf.setBounds(0, 400, 200, 200);

		JPanel pp = (JPanel) getContentPane();
		pp.setLayout(null);
		pp.add(pd);
		pp.add(pc);
		pp.add(pw);
		pp.add(pf);

		FMenu mnu = new FMenu(cmd);
		setJMenuBar(mnu);

		setVisible(true);
	}
}
