   M S B A M L   `   `   `  ����L  HSoundOryc.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:SoundOryc.Desktop.ViewModelSoundOryc.Desktop.ViewModel  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      a ]Itenso.Windows.Controls.ListViewLayout, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null�dclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout&Itenso.Windows.Controls.ListViewLayout 5	      f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5
      (    "SoundOryc.Desktop.View.ContentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;model)clr-namespace:SoundOryc.Desktop.ViewModel     5      T PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;controls,http://metro.mahapps.com/winfx/xaml/controls  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5      octrldclr-namespace:Itenso.Windows.Controls.ListViewLayout;assembly=Itenso.Windows.Controls.ListViewLayout  5	      WcmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform  5
      .command http://www.galasoft.ch/mvvmlight  5      $	��360��5        � DataContext  5      �� *	Content+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source  Key�� 5   
    5      �� 5      $ Resources.xaml?�6&   �� 5      �� 5      	boolToVis 63   5      %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   �� 5       $��25 �6    � ColumnDefinitions 5"   
   �� 5#      $	��15* �6   �� 5$      $	��120 �6   �� 5%      $	��128 �6   �� 5&      $	��120 �6   �� 5'      $	��14* �6   .+�5)   
   �� ���#898c88$��0��6s   $��0��6�   $��5��6�   $��
40,24,40,0q�6�   y�6#   �� *isContentVisibleUp+  	boolToVis �� 	Converter# [ 6�   �� 5*   
   -   5         ��Name$ btnSongs��5*        ButtonSelectSearchType#��[ 6s   $��0��6�   $��1��6�   $��13(�6�   $
��Thin"�6�   $��songs��6  	 �� 	ClickMode$	 Press=�6  $��70��6&  $��25��61  $��Right=�6=  $��Stretch=�6Y  $	��Top=�6~  $��Disabled=�6�  $��	10,2,10,5q�6�  
 � UseLayoutRounding
 .  $��0,0,25,0q�6  y�6#   �� *isContentVisibleUp+# [ {�6�   �� *songsEnabled+��6�  �� *
songsClick+6  �� 5+   
   -   5        $ 
btnArtists��5+      #��[ 6u   $��0��6�   $��2��6�   $��13(�6�   $
��Thin"�6�   $��artists��6  $	 Press=�6  $��25��6-  $��Stretch=�69  $	��Top=�6^  $��Disabled=�6}  $��	10,2,10,5q�6�  
 .  $��	31,0,34,0q�6   y�6%   �� *isContentVisibleUp+# [ {�6�   �� *artistsEnabled+��6�  �� *artistsClick+6   �� 5,   
   -   5        $ 	btnAlbums��5,      #��[ 6t   $��0��6�   $��3��6�   $��13(�6�   $
��Thin"�6�   $��albums��6  $	 Press=�6  $��67��6*  $��25��65  $��Right=�6A  $��Stretch=�6]  $	��Top=�6�  $��Disabled=�6�  $��	10,2,10,5q�6�  
 .  $��0,-0.066,25,0.065q�6#  y�6$   �� *isContentVisibleUp+# [ {�6�   �� *albumsEnabled+��6  �� *albumsClick+6#  �� 5-   
   -   5         ��Name$ lblPlaylistName��5-      $��0��6�   $��1��6�   $��4��6�   ���	#FF898C88
������ $
��Thin"�6  }�. $��13(�6)  y�6)   �� *isContentPlaylistVisible+# [ ��6   �� *playlistName+6)  �� 5.   
   -   5         ��Name$ lvSongs��5.      
������ B  <Itenso.Windows.Controls.ListViewLayout.ListViewLayoutManager   Enabled . $��0��6h   $��1��6y   $��
0, 5, 0, 0q�6�   $��Stretch=�6�   $��5��6�     CustomListViewItemStyle#���  6�    J� 	AllowDrop . ��6�   Z� ��6:  �� *	songsList+.  (System.Windows.Interactivity.Interaction   Triggers 5/      /  )System.Windows.Interactivity.EventTrigger  50         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 51      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand .    Command 6-   �� *addQueueAlone+6O   52        53      $ SelectionChanged��6!   . 54         6.   �� *SelectionChangedCommand+   CommandParameter 6Z   �� *SelectedItems+ �� ElementName$ lvSongs��55       � ContextMenu 57      �� 58      -   5         ��Name$
 menu��58      y�6,   �� *isContextmenuVisible+# [ .@�59      m� -   5         m�Name$ addQueue��59      $��Add to Queue��61   
������� m� Command 6`   �� *
addQueue+ m� CommandParameter 6~   ��  �� RelativeSource ��  �� AncestorType$ ContextMenuL� �� Path$" PlacementTarget.SelectedItem�5:      m� 5;      -   5        $ addPlaylist��5;      $��Add to Playlist��65   
�������y�6N   �� *isAddPlaylistMIVisible+# [  6�   �� $ DataContext.addPlaylist� ��  �� Mode$ FindAncestor=�$ ListViewL�.@�5<      m� -	   5        $ 	createNew��5<   #   $��Create new...��67   
������� 6N   �� *	createNew+ 6m   ��  �� $ ContextMenuL�$" PlacementTarget.SelectedItem�6�   5=      m� 5>      -
   5        $ 
deleteSong��5>      $��Delete from Playlist��64   y�6R   �� *isDeleteSongMIVisible+# [  6�   �� *deleteSongFromPlayList+ 6�   ��  �� $ ContextMenuL�$" PlacementTarget.SelectedItem�5?       �� View 5A      �� 5B        myHeaderStyle!  �� ColumnHeaderContainerStyle#  [ 6   .P�5C      �� ?  9Itenso.Windows.Controls.ListViewLayout.ProportionalColumn!   Width$! 1Q�6&   " �� DisplayMemberBinding" 6I   �� *	numList+�� 5D      $! 4Q�6&   " 6H   �� *
songName+�� 5E      $! 4Q�6&   " 6H   �� *
artistName+�� 5F      $! 2Q�6&   " 6H   �� *
duration+�� 5G      $! 1Q�6&   # �� CellTemplate# 5H      �� 5I      .R�5J   "   �� $ ��Name$$ downloadImage��6(   $$��/Resources/cloud-computing.png��6?   $��18��6g   $��18��6r   % � ToolTip$% Generate download link��6   ��5K   &   �� 5L   *   & �� 
TargetType"& ��60   ' �� Triggers' 5M   .   P� 5N   2   ( P� Property( �@J�IsMouseOver) P� Value) . . �5O   6   �� * �� Property* �@J�Effect+ �� Value+ 5P   :   3  -System.Windows.Media.Effects.DropShadowEffect  5Q   >   ,   ShadowDepth$, 0Q�6O   -   Color$- 	LightGray��6_   .   Opacity$
. 0.70Q�6q   /   
BlurRadius$/ 5Q�6�   5S   7   5T   3   5V   +   5X   #   5Y      5[      5\      5_      �� 5a   
   -   5        $ loadNextListButton��5a        ButtonStyle#��[ 6|   $��2��6�   $��	76,4,34,3q�6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6  {�. $��1��6'  $% Next search page��66  0 J� RenderTransformOrigin$0 
0.45,1.625&�6Q  $��2��6t  $��10��6�    loadNextButton#���  6�  y�6-   �� *isContentVisible+# [ 6�  �� 5c   
   -   5        $ loadPrevListButton��5c      #��[ 6{   $��2��6�   $��0,4,80,3q�6�   
������ $��0,0,0,0q�6�   $��0,0,0,0q�6�   $��1(�6  {�. $��1��6%  $% Previous search page��65  $0 
0.45,1.625&�6T  $��2��6w  $��Right=�6�  $��10��6�    loadPrevButton#���  6�  y�6-   �� *isContentVisible+# [ 6�  �� 5e   
   -   5        $ lblPage��5e      $��2��6�   $��2��6�   $��Arial Unicode MS)�6�   ���	#FF898C88
������ }�. $��10(�6  $��Center=�6"  $��0,0,51,0q�6F  $��Right=�6X  $��29��6t  ��6"   �� *lblPageContent+y�6E   �� *isContentVisible+# [ 6t  5f      5g      