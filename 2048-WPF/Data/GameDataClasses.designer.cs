#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2048_WPF.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="GameData")]
	public partial class GameDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPlayer(Player instance);
    partial void UpdatePlayer(Player instance);
    partial void DeletePlayer(Player instance);
    partial void InsertGameStatus(GameStatus instance);
    partial void UpdateGameStatus(GameStatus instance);
    partial void DeleteGameStatus(GameStatus instance);
    #endregion
		
		public GameDataClassesDataContext() : 
				base(global::_2048_WPF.Properties.Settings.Default.GameDataConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public GameDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GameDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GameDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public GameDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Player> Players
		{
			get
			{
				return this.GetTable<Player>();
			}
		}
		
		public System.Data.Linq.Table<GameStatus> GameStatus
		{
			get
			{
				return this.GetTable<GameStatus>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Player")]
	public partial class Player : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _PlayerName;
		
		private System.Nullable<int> _PlayerScore;
		
		private System.Nullable<int> _PlayerMoves;
		
		private string _GameBoard;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPlayerNameChanging(string value);
    partial void OnPlayerNameChanged();
    partial void OnPlayerScoreChanging(System.Nullable<int> value);
    partial void OnPlayerScoreChanged();
    partial void OnPlayerMovesChanging(System.Nullable<int> value);
    partial void OnPlayerMovesChanged();
    partial void OnGameBoardChanging(string value);
    partial void OnGameBoardChanged();
    #endregion
		
		public Player()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerName", DbType="VarChar(255)")]
		public string PlayerName
		{
			get
			{
				return this._PlayerName;
			}
			set
			{
				if ((this._PlayerName != value))
				{
					this.OnPlayerNameChanging(value);
					this.SendPropertyChanging();
					this._PlayerName = value;
					this.SendPropertyChanged("PlayerName");
					this.OnPlayerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerScore", DbType="Int")]
		public System.Nullable<int> PlayerScore
		{
			get
			{
				return this._PlayerScore;
			}
			set
			{
				if ((this._PlayerScore != value))
				{
					this.OnPlayerScoreChanging(value);
					this.SendPropertyChanging();
					this._PlayerScore = value;
					this.SendPropertyChanged("PlayerScore");
					this.OnPlayerScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayerMoves", DbType="Int")]
		public System.Nullable<int> PlayerMoves
		{
			get
			{
				return this._PlayerMoves;
			}
			set
			{
				if ((this._PlayerMoves != value))
				{
					this.OnPlayerMovesChanging(value);
					this.SendPropertyChanging();
					this._PlayerMoves = value;
					this.SendPropertyChanged("PlayerMoves");
					this.OnPlayerMovesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameBoard", DbType="VarChar(1000)")]
		public string GameBoard
		{
			get
			{
				return this._GameBoard;
			}
			set
			{
				if ((this._GameBoard != value))
				{
					this.OnGameBoardChanging(value);
					this.SendPropertyChanging();
					this._GameBoard = value;
					this.SendPropertyChanged("GameBoard");
					this.OnGameBoardChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GameStatus")]
	public partial class GameStatus : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CurrentPlayer;
		
		private System.Nullable<int> _ContinueFlag;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCurrentPlayerChanging(string value);
    partial void OnCurrentPlayerChanged();
    partial void OnContinueFlagChanging(System.Nullable<int> value);
    partial void OnContinueFlagChanged();
    #endregion
		
		public GameStatus()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CurrentPlayer", DbType="VarChar(255)")]
		public string CurrentPlayer
		{
			get
			{
				return this._CurrentPlayer;
			}
			set
			{
				if ((this._CurrentPlayer != value))
				{
					this.OnCurrentPlayerChanging(value);
					this.SendPropertyChanging();
					this._CurrentPlayer = value;
					this.SendPropertyChanged("CurrentPlayer");
					this.OnCurrentPlayerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContinueFlag", DbType="Int")]
		public System.Nullable<int> ContinueFlag
		{
			get
			{
				return this._ContinueFlag;
			}
			set
			{
				if ((this._ContinueFlag != value))
				{
					this.OnContinueFlagChanging(value);
					this.SendPropertyChanging();
					this._ContinueFlag = value;
					this.SendPropertyChanged("ContinueFlag");
					this.OnContinueFlagChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
