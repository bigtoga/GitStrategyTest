namespace StockSharp.Algo.Storages.Binary.Snapshot
{
	using System;
	using System.Runtime.InteropServices;

	using Ecng.Common;
	using Ecng.Interop;
	using Ecng.Serialization;

	using StockSharp.Messages;

	/// <summary>
	/// Implementation of <see cref="ISnapshotSerializer{TKey,TMessage}"/> in binary format for <see cref="PositionChangeMessage"/>.
	/// </summary>
	public class PositionBinarySnapshotSerializer : ISnapshotSerializer<SecurityId, PositionChangeMessage>
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
		private struct PositionSnapshot
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string SecurityId;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string Portfolio;

			public long LastChangeServerTime;
			public long LastChangeLocalTime;

			public BlittableDecimal? BeginValue;
			public BlittableDecimal? CurrentValue;
			public BlittableDecimal? BlockedValue;
			public BlittableDecimal? CurrentPrice;
			public BlittableDecimal? AveragePrice;
			public BlittableDecimal? UnrealizedPnL;
			public BlittableDecimal? RealizedPnL;
			public BlittableDecimal? VariationMargin;
			public short? Currency;
			public BlittableDecimal? Leverage;
			public BlittableDecimal? Commission;
			public BlittableDecimal? CurrentValueInLots;
			public byte? State;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string DepoName;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string BoardCode;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string ClientCode;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = Sizes.S100)]
			public string Description;

			public byte? LimitType;
			public long? ExpirationDate;

			public BlittableDecimal? CommissionTaker;
			public BlittableDecimal? CommissionMaker;
			public BlittableDecimal? SettlementPrice;
		}

		Version ISnapshotSerializer<SecurityId, PositionChangeMessage>.Version { get; } = SnapshotVersions.V21;

		string ISnapshotSerializer<SecurityId, PositionChangeMessage>.Name => "Positions";

		byte[] ISnapshotSerializer<SecurityId, PositionChangeMessage>.Serialize(Version version, PositionChangeMessage message)
		{
			if (version == null)
				throw new ArgumentNullException(nameof(version));

			if (message == null)
				throw new ArgumentNullException(nameof(message));

			var snapshot = new PositionSnapshot
			{
				SecurityId = message.SecurityId.ToStringId().VerifySize(Sizes.S100),
				Portfolio = message.PortfolioName.VerifySize(Sizes.S100),
				LastChangeServerTime = message.ServerTime.To<long>(),
				LastChangeLocalTime = message.LocalTime.To<long>(),
				DepoName = message.DepoName,
				LimitType = (byte?)message.LimitType,
				BoardCode = message.BoardCode,
				ClientCode = message.ClientCode,
				Description = message.Description,
			};

			foreach (var change in message.Changes)
			{
				switch (change.Key)
				{
					case PositionChangeTypes.BeginValue:
						snapshot.BeginValue = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.CurrentValue:
						snapshot.CurrentValue = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.BlockedValue:
						snapshot.BlockedValue = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.CurrentPrice:
						snapshot.CurrentPrice = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.AveragePrice:
						snapshot.AveragePrice = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.UnrealizedPnL:
						snapshot.UnrealizedPnL = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.RealizedPnL:
						snapshot.RealizedPnL = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.VariationMargin:
						snapshot.VariationMargin = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.Currency:
						snapshot.Currency = (short)(CurrencyTypes)change.Value;
						break;
					case PositionChangeTypes.Leverage:
						snapshot.Leverage = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.Commission:
						snapshot.Commission = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.CurrentValueInLots:
						snapshot.CurrentValueInLots = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.State:
						snapshot.State = (byte)(PortfolioStates)change.Value;
						break;
					case PositionChangeTypes.ExpirationDate:
						snapshot.ExpirationDate = change.Value.To<long?>();
						break;
					case PositionChangeTypes.CommissionTaker:
						snapshot.CommissionTaker = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.CommissionMaker:
						snapshot.CommissionMaker = (BlittableDecimal)(decimal)change.Value;
						break;
					case PositionChangeTypes.SettlementPrice:
						snapshot.SettlementPrice = (BlittableDecimal)(decimal)change.Value;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}

			var buffer = new byte[typeof(PositionSnapshot).SizeOf()];

			var ptr = snapshot.StructToPtr();
			ptr.CopyTo(buffer);
			ptr.FreeHGlobal();

			return buffer;
		}

		PositionChangeMessage ISnapshotSerializer<SecurityId, PositionChangeMessage>.Deserialize(Version version, byte[] buffer)
		{
			if (version == null)
				throw new ArgumentNullException(nameof(version));

			using (var handle = new GCHandle<byte[]>(buffer))
			{
				var snapshot = handle.CreatePointer().ToStruct<PositionSnapshot>(true);

				var posMsg = new PositionChangeMessage
				{
					SecurityId = snapshot.SecurityId.ToSecurityId(),
					PortfolioName = snapshot.Portfolio,
					ServerTime = snapshot.LastChangeServerTime.To<DateTimeOffset>(),
					LocalTime = snapshot.LastChangeLocalTime.To<DateTimeOffset>(),
					ClientCode = snapshot.ClientCode,
					DepoName = snapshot.DepoName,
					BoardCode = snapshot.BoardCode,
					LimitType = (TPlusLimits?)snapshot.LimitType,
				}
				.TryAdd(PositionChangeTypes.BeginValue, snapshot.BeginValue, true)
				.TryAdd(PositionChangeTypes.CurrentValue, snapshot.CurrentValue, true)
				.TryAdd(PositionChangeTypes.BlockedValue, snapshot.BlockedValue, true)
				.TryAdd(PositionChangeTypes.CurrentPrice, snapshot.CurrentPrice, true)
				.TryAdd(PositionChangeTypes.AveragePrice, snapshot.AveragePrice, true)
				.TryAdd(PositionChangeTypes.UnrealizedPnL, snapshot.UnrealizedPnL, true)
				.TryAdd(PositionChangeTypes.RealizedPnL, snapshot.RealizedPnL, true)
				.TryAdd(PositionChangeTypes.VariationMargin, snapshot.VariationMargin, true)
				.TryAdd(PositionChangeTypes.Leverage, snapshot.Leverage, true)
				.TryAdd(PositionChangeTypes.Commission, snapshot.Commission, true)
				.TryAdd(PositionChangeTypes.CurrentValueInLots, snapshot.CurrentValueInLots, true)
				.TryAdd(PositionChangeTypes.CommissionTaker, snapshot.CommissionTaker, true)
				.TryAdd(PositionChangeTypes.CommissionMaker, snapshot.CommissionMaker, true)
				.TryAdd(PositionChangeTypes.SettlementPrice, snapshot.SettlementPrice, true)
				.TryAdd(PositionChangeTypes.ExpirationDate, snapshot.ExpirationDate.To<DateTimeOffset?>())
				;

				if (snapshot.Currency != null)
					posMsg.Add(PositionChangeTypes.Currency, (CurrencyTypes)snapshot.Currency.Value);

				if (snapshot.State != null)
					posMsg.Add(PositionChangeTypes.State, (PortfolioStates)snapshot.State.Value);

				return posMsg;
			}
		}

		SecurityId ISnapshotSerializer<SecurityId, PositionChangeMessage>.GetKey(PositionChangeMessage message)
		{
			return message.SecurityId;
		}

		PositionChangeMessage ISnapshotSerializer<SecurityId, PositionChangeMessage>.CreateCopy(PositionChangeMessage message)
		{
			return (PositionChangeMessage)message.Clone();
		}

		void ISnapshotSerializer<SecurityId, PositionChangeMessage>.Update(PositionChangeMessage message, PositionChangeMessage changes)
		{
			foreach (var pair in changes.Changes)
			{
				message.Changes[pair.Key] = pair.Value;
			}

			message.LocalTime = changes.LocalTime;
			message.ServerTime = changes.ServerTime;
		}

		DataType ISnapshotSerializer<SecurityId, PositionChangeMessage>.DataType => DataType.PositionChanges;
	}
}