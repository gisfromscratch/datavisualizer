#include "InMemoryTableModel.h"

InMemoryTableModel::InMemoryTableModel(QFile *file, QObject *parent)
    : QAbstractTableModel(parent), _rowCount(0), _columnCount(0)
{
    if (0 != file && file->open(QIODevice::ReadOnly))
    {
        // Read the whole file into memory
        QTextStream inputStream(file);
        QString line;
        QStringList tokens;
        QStringList::const_iterator end;
        for (int recordIndex = -1; !inputStream.atEnd(); recordIndex++)
        {
            line = inputStream.readLine();
            if (-1 == recordIndex)
            {
                // Determine the column count
                tokens = line.split(',');
                _columnCount = tokens.length();
            }
            else
            {
                // Read the values
                tokens = line.split(',');
                end = tokens.end();
                QStringList values;
                for (QStringList::const_iterator tokenIterator = tokens.begin(); tokenIterator != end; tokenIterator++)
                {
                    values.append(*tokenIterator);
                }
                _data.insert(recordIndex, values);
            }
        }

        _rowCount = _data.size();
    }
}

int InMemoryTableModel::rowCount(const QModelIndex&) const
{
    return _rowCount;
}

int InMemoryTableModel::columnCount(const QModelIndex&) const
{
    return _columnCount;
}

QVariant InMemoryTableModel::data(const QModelIndex &index, int role) const
{
    if (Qt::DisplayRole != role)
    {
        return QVariant();
    }

    if (!_data.contains(index.row()))
    {
        return QString("NO ROW");
    }

    QStringList values = _data[index.row()];
    if (values.length() <= index.column())
    {
        return QString("NO COLUMN");
    }

    return values.at(index.column());
}
