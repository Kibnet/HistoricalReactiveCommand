﻿using System;
using System.Reactive;

namespace HistoricalReactiveCommand
{
    public interface IHistory
    {
        IObservable<bool> CanUndo { get; }
        IObservable<bool> CanRedo { get; }
        IObservable<bool> CanRecord { get; }
        IObservable<bool> CanClear { get; }

        IObservable<HistoryEntry> Undo(Func<HistoryEntry, IObservable<HistoryEntry>> discard);
        IObservable<HistoryEntry> Redo(Func<HistoryEntry, IObservable<HistoryEntry>> execute);
        IObservable<HistoryEntry> Record(HistoryEntry entry, Func<HistoryEntry, IObservable<HistoryEntry>> execute);
        IObservable<Unit> Clear();
    }
}