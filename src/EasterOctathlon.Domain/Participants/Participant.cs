using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace EasterOctathlon.Participants;

public class Participant : FullAuditedAggregateRoot<int>
{
    public Guid Uid { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? NickName { get; private set; }
    public Gender Gender { get; private set; }
    public DateOnly? DateOfBirth { get; private set; }
    public bool IsActive { get; private set; }
    public string? Note { get; private set; }

    protected Participant()
    {
    }

    public Participant(
        Guid uid,
        string firstName,
        string lastName,
        string? nickName,
        Gender gender,
        DateOnly? dateOfBirth,
        bool isActive,
        string? note)
    {
        SetUid(uid);
        SetName(firstName, lastName);
        SetNickName(nickName);
        SetGender(gender);
        SetDateOfBirth(dateOfBirth);
        SetIsActive(isActive);
        SetNote(note);
    }

    public void Update(
        string firstName,
        string lastName,
        string? nickName,
        Gender gender,
        DateOnly? dateOfBirth,
        bool isActive,
        string? note)
    {
        SetName(firstName, lastName);
        SetNickName(nickName);
        SetGender(gender);
        SetDateOfBirth(dateOfBirth);
        SetIsActive(isActive);
        SetNote(note);
    }

    private void SetUid(Guid uid)
    {
        if (uid == Guid.Empty)
        {
            throw new ArgumentException("Participant UID cannot be empty.", nameof(uid));
        }

        Uid = uid;
    }

    private void SetName(string firstName, string lastName)
    {
        FirstName = Check.Length(
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName))!,
            nameof(firstName),
            ParticipantConsts.MaxFirstNameLength)!;

        LastName = Check.Length(
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName))!,
            nameof(lastName),
            ParticipantConsts.MaxLastNameLength)!;
    }

    private void SetNickName(string? nickName)
    {
        NickName = NormalizeNullableString(nickName, nameof(nickName), ParticipantConsts.MaxNickNameLength);
    }

    private void SetGender(Gender gender)
    {
        if (!Enum.IsDefined(gender))
        {
            throw new ArgumentOutOfRangeException(nameof(gender), gender, "Invalid participant gender.");
        }

        Gender = gender;
    }

    private void SetDateOfBirth(DateOnly? dateOfBirth)
    {
        if (dateOfBirth.HasValue && dateOfBirth.Value > DateOnly.FromDateTime(DateTime.UtcNow))
        {
            throw new ArgumentException("Participant date of birth cannot be in the future.", nameof(dateOfBirth));
        }

        DateOfBirth = dateOfBirth;
    }

    private void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    private void SetNote(string? note)
    {
        Note = NormalizeNullableString(note, nameof(note), ParticipantConsts.MaxNoteLength);
    }

    private static string? NormalizeNullableString(string? value, string paramName, int maxLength)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return Check.Length(value.Trim(), paramName, maxLength);
    }
}
