   M S B A M L   `   `   `  ����L  HSoundOryc.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SoundOryc.DesktopSoundOryc.Desktop  5   	   ?$clr-namespace:SoundOryc.Desktop.ViewSoundOryc.Desktop.View  5   	   T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	   f bMahApps.Metro.SimpleChildWindow, Version=1.3.0.0, Culture=neutral, PublicKeyToken=bbbfdff7f500a992zVclr-namespace:MahApps.Metro.SimpleChildWindow;assembly=MahApps.Metro.SimpleChildWindowMahApps.Metro.SimpleChildWindow 5	   	   fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs 5   	   '    !SoundOryc.Desktop.View.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SoundOryc.Desktop     5   	   5View$clr-namespace:SoundOryc.Desktop.View     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   tsimpleChildWindowVclr-namespace:MahApps.Metro.SimpleChildWindow;assembly=MahApps.Metro.SimpleChildWindow     5	   	   WdialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5   	   $	��600��5   	   $	��600��6   $	��600��5   	   $	��600��6   (  "MahApps.Metro.Controls.MetroWindow    NonActiveGlowBrush  �#2b323a   NonActiveBorderBrush �#2b323a    NonActiveWindowTitleBrush �#2b323a � DataContext 5   	   �� *Main+   Locator �� Source# [  8  2MahApps.Metro.Controls.Dialogs.DialogParticipation   Register 5   	   ��  � 	Resources 5       �� MergedDictionaries �� Source  Key�� 5   
    5      �� 5      $ Resources.xaml?�6&   �� 5      �� 5      	boolToVis 63   5      %    5      	   Flyouts	 5$      +  %MahApps.Metro.Controls.FlyoutsControl  5%   
   .@�5&      #  MahApps.Metro.Controls.Flyout  -   5        
  Name$
 	flSidebar��5&         Position$
 Left=�6O   $	��200��6_   $��	0,40,0,30q�6k      CloseButtonVisibility$ 	Collapsed=�6~   ���#2b323a   TitleVisibility$ 	Collapsed=�6�      Theme$ Accent=�6�      IsOpen 61   �� *	isSOpened+.��5'      (   "SoundOryc.Desktop.View.SidebarView  $��0��6$   $��0��64   $��5��6A   5(      5)      .��5-      �  � RowDefinitions 5.   
   �� 5/      $��45 �6   �� 50      $��25 �6   �� 51      $��* �6   �� 52      $��60 �6    � ColumnDefinitions 54   
   �� 55      $
��197* �6   �� 56      $
��100* �6   �� 57      $��44 �6   �� 58      $	��91* �6   �� 59      $
��197* �6   .+�5>   
   (   "SoundOryc.Desktop.View.ContentView  -   5          Name$ content��5>      $��0��6,   $��1��6<   $��2��6I   $��5��6Z   $��0,20,0,0q�6n   +   %SoundOryc.Desktop.View.NavigationView  5?   
   $��0��6   $��0��6.   $��5��6;   '   !SoundOryc.Desktop.View.PlayerView  5@   
   $��0��6   $��3��6+   $��5��68   �� 5A   
   $��0��6   $��1��6$   $��2��61   $��5��6B   ���#2b323ay�6g   �� *isContentVisible+  	boolToVis �� 	Converter# [ )	  #MahApps.Metro.Controls.ProgressRing	  5B   
   -   5         	 Name$ pbRing��5B       $��2��60   $��Center=�6=   $��Center=�6Z   $��86,123,79,157q�6v   $��1��6�   $��3��6�   ���#898c88$��59��6�   $��58��6�    	  IsActive 6�   �� *isPbRingActive+6�   1
  +MahApps.Metro.SimpleChildWindow.ChildWindow
  5D   
   -   5         
 Name$ queueWindow��5D   (   $��2��6=   $��1��6J   $��4��6Z    
  CloseByEscape . $��Stretch=�6�   $��Stretch=�6�   $��15q�6�   ���#2b323a 
  AllowFocusElement .   
  TitleBarBackground �#2b323a 
  ShowTitleBar .   
  EnableDropShadow .  $	��171��6�  $��12,0,-15,47q�6�  $��Bottom=�6�  $��Center=�6�  $	��410��6�  $��2��6�   
  	GlowBrush$ 	#FF898C88��6�  ���	#FF898C88$��1,1,1,0q�6,   
  IsOpen 6�   �� *	isQOpened+ 
  OverlayBrush 6�   Z� .��5E      &    SoundOryc.Desktop.View.QueueView  5F      5H      5I      